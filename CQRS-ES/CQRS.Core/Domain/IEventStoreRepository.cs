using CQRS.Core.Events;

namespace CQRS.Core.Domain
{
    public interface IEventStoreRepository
    {
        Task<bool> SaveAsync(BaseEventModel @event);
        Task<List<BaseEventModel>> FindAllAsync();
        Task<List<BaseEventModel>> FindByAggregateId(Guid aggregateId);
    }
}