using CQRS.Core.Domain;

namespace CQRS.Core.Handlers
{
    public interface IEventSourcingHandler<T>
    {
        void Save(AggregateRoot aggregate);
        T GetById(string id);
        void RepublishEvents();
    }
}