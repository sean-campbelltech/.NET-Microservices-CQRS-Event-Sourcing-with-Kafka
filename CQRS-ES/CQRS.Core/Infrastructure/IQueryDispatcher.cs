using CQRS.Core.Domain;
using CQRS.Core.Queries;

namespace CQRS.Core.Infrastructure
{
    public interface IQueryDispatcher<U>
    {
        void RegisterHandler<T>(Func<T, Task<List<U>>> handler) where T : BaseQuery;
        Task<List<U>> Send(BaseQuery query);
    }
}