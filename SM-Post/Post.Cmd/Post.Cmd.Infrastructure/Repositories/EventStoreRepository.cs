using CQRS.Core.Domain;
using CQRS.Core.Events;

namespace Post.Cmd.Infrastructure.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        public Task<List<BaseEventModel>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BaseEventModel>> FindByAggregateId(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(BaseEventModel @event)
        {
            throw new NotImplementedException();
        }
    }
}