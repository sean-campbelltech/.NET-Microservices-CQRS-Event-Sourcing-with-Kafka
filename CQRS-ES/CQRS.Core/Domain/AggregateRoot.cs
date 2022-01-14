using CQRS.Core.Events;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Core.Domain
{
    public abstract class AggregateRoot
    {
        protected Guid _id;
        private readonly List<BaseEvent> _changes = new List<BaseEvent>();

        public int Version { get; set; }

        public IEnumerable<BaseEvent> GetUncommitedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        // push atomic aggregate changes to local history for further processing (EventStore.SaveEvents)
        private void ApplyChange(BaseEvent @event, bool isNew)
        {
            var method = this.GetType().GetMethod("Apply");
            if (method == null)
                throw new ArgumentNullException($"The apply method was not found in the aggregate for {@event.GetType().Name}");

            method.Invoke(this, new object[] { @event });
            if (isNew) _changes.Add(@event);
        }


        protected void RaiseEvent(BaseEvent @event)
        {
            ApplyChange(@event, true);
        }

        public void ReplayEvents(IEnumerable<BaseEvent> events)
        {
            foreach (var @event in events) ApplyChange(@event, false);
        }
    }
}