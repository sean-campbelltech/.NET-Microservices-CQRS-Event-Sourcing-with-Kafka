using CQRS.Core.Events;

namespace CQRS.Core.Infrastructure
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<BaseEvent> events, int expectedVersion);
        List<BaseEvent> GetEvents(Guid aggregateId);
        List<Guid> GetAggregateIds();
    }
}