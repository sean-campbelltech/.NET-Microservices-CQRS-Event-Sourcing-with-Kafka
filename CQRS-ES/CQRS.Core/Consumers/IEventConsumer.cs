using CQRS.Core.Events;

namespace CQRS.Core.Consumers
{
    public interface IEventConsumer
    {
        void Consume(string topic);
    }
}