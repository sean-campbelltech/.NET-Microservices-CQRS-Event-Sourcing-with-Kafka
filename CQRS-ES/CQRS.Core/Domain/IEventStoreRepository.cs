using CQRS.Core.Events;

namespace CQRS.Core.Domain
{
    // Remember to say: Remember I've said that no update or delete operations are allow for event store. It should be Immutable / unchangable 
    public interface IEventStoreRepository<T> where T : BaseEventEntity
    {
        Task SaveAsync(T @event);
        Task<List<T>> FindAllAsync();
        Task<List<T>> FindByAggregateId(Guid aggregateId);
    }
}