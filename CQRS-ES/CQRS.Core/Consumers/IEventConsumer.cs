using CQRS.Core.Events;

namespace CQRS.Core.Consumers
{
    public interface IEventConsumer
    {
        void Consume<T>(string topic) where T : BaseEvent;
    }
}