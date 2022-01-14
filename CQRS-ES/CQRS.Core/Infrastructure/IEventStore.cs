using CQRS.Core.Events;

namespace CQRS.Core.Infrastructure
{
    public interface IEventStore
    {
        void SaveEvents(string aggregateId, IEnumerable<BaseEvent> events, int expectedVersion);
        List<BaseEvent> GetEvents(string aggregateId);
        List<string> GetAggregateIds();
    }
}