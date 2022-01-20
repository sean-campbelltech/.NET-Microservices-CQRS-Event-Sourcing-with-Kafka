using CQRS.Core.Infrastructure;
using CQRS.Core.Queries;
using Post.Query.Domain.Entities;

namespace Post.Query.Infrastructure.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher<PostEntity>
    {
        private readonly Dictionary<Type, List<Func<BaseQuery, List<PostEntity>>>> _routes = new Dictionary<Type, List<Func<BaseQuery, List<PostEntity>>>>();

        public void RegisterHandler<T>(Func<T, List<PostEntity>> handler) where T : BaseQuery
        {
            if (!_routes.TryGetValue(typeof(T), out List<Func<BaseQuery, List<PostEntity>>>? handlers))
            {
                handlers = new List<Func<BaseQuery, List<PostEntity>>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add(x => handler((T)x));
        }

        public List<PostEntity> Send(BaseQuery query)
        {
            if (_routes.TryGetValue(typeof(BaseQuery), out List<Func<BaseQuery, List<PostEntity>>>? handlers))
            {
                if (handlers?.Count != 1)
                    throw new IndexOutOfRangeException("Cannot send query to more than one handler!");

                return handlers[0](query);
            }
            else
            {
                throw new ArgumentNullException(nameof(handlers), "No query handler registered!");
            }
        }
    }
}