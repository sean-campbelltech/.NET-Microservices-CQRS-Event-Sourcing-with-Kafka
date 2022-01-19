using CQRS.Core.Domain;
using CQRS.Core.Handlers;
using CQRS.Core.Infrastructure;
using CQRS.Core.Producers;
using Post.Cmd.Domain.Aggregates;

namespace Post.Cmd.Infrastructure.Handlers
{
    public class EventSourcingHandler : IEventSourcingHandler<PostAggregate>
    {
        private readonly IEventStore _eventStore;
        private readonly IEventProducer _eventProducer;

        public EventSourcingHandler(IEventStore eventStore, IEventProducer eventProducer)
        {
            _eventStore = eventStore;
            _eventProducer = eventProducer;
        }

        public void Save(AggregateRoot aggregate)
        {
            _eventStore.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), aggregate.Version);
            aggregate.MarkChangesAsCommitted();
        }

        public PostAggregate GetById(Guid aggregateId)
        {
            var aggregate = new PostAggregate();
            var events = _eventStore.GetEvents(aggregateId);

            if (events?.Any() != true) return aggregate;

            aggregate.ReplayEvents(events);
            var latestVersion = events?.Select(x => x.Version)?.Max() ?? -1;
            aggregate.Version = latestVersion;

            return aggregate;
        }

        public void RepublishEvents()
        {
            var aggregateIds = _eventStore.GetAggregateIds();

            if (aggregateIds?.Any() != true) return;

            foreach (var aggregateId in aggregateIds)
            {
                var aggregate = GetById(aggregateId);

                if (aggregate == null || !aggregate.Active) continue;

                var events = _eventStore.GetEvents(aggregateId);

                foreach (var @event in events)
                {
                    _eventProducer.Produce(@event.GetType().Name, @event);
                }
            }
        }
    }
}