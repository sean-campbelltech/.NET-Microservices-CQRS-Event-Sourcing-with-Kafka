using CQRS.Core.Events;

namespace CQRS.Core.Producers
{
    public interface IEventProducer
    {
        Task ProduceAsync(string topic, BaseEvent @event);
    }
}