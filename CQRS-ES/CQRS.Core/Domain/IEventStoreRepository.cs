using CQRS.Core.Events;

namespace CQRS.Core.Domain
{
    public interface IEventStoreRepository
    {
        Task<bool> SaveAsync(EventModel @event);
        Task<List<EventModel>> FindAllAsync();
        Task<List<EventModel>> FindByAggregateId(Guid aggregateId);
    }
}