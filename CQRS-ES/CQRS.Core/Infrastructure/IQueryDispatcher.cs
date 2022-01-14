using CQRS.Core.Domain;
using CQRS.Core.Queries;

namespace CQRS.Core.Infrastructure
{
    public interface IQueryDispatcher<U>
    {
        void RegisterHandler<T>(Action<T> handler) where T : BaseQuery;
        List<U> Send(BaseQuery query);
    }
}