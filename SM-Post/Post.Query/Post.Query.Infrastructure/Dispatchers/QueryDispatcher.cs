using CQRS.Core.Infrastructure;
using CQRS.Core.Queries;
using Post.Query.Domain.Entities;

namespace Post.Query.Infrastructure.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher<PostEntity>
    {
        public void RegisterHandler<T>(Action<T> handler) where T : BaseQuery
        {
            throw new NotImplementedException();
        }

        public List<PostEntity> Send(BaseQuery query)
        {
            throw new NotImplementedException();
        }
    }
}