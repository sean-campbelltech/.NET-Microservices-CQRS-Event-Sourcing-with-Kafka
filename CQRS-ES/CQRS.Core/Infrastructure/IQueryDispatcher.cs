using CQRS.Core.Domain;
using CQRS.Core.Queries;

namespace CQRS.Core.Infrastructure
{
    public interface IQueryDispatcher<U>
    {
        void RegisterHandler<T>(Func<T, List<U>> handler) where T : BaseQuery;
        List<U> Send(BaseQuery query);
    }
}