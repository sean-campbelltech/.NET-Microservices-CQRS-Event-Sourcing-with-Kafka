using CQRS.Core.Infrastructure;
using CQRS.Core.Queries;
using Post.Query.Domain.Entities;

namespace Post.Query.Infrastructure.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher<PostEntity>
    {
        private readonly Dictionary<Type, List<Func<BaseQuery, Task<List<PostEntity>>>>> _routes = new();

        public void RegisterHandler<TQuery>(Func<TQuery, Task<List<PostEntity>>> handler) where TQuery : BaseQuery
        {
            if (!_routes.TryGetValue(typeof(TQuery), out List<Func<BaseQuery, Task<List<PostEntity>>>> handlers))
            {
                handlers = new List<Func<BaseQuery, Task<List<PostEntity>>>>();
                _routes.Add(typeof(TQuery), handlers);
            }

            handlers.Add(x => handler((TQuery)x));
        }

        public async Task<List<PostEntity>> Send(BaseQuery query)
        {
            if (_routes.TryGetValue(query.GetType(), out List<Func<BaseQuery, Task<List<PostEntity>>>> handlers))
            {
                if (handlers?.Count != 1)
                    throw new IndexOutOfRangeException("Cannot send query to more than one handler!");

                return await handlers[0](query);
            }
            else
            {
                throw new ArgumentNullException(nameof(handlers), "No query handler registered!");
            }
        }
    }
}