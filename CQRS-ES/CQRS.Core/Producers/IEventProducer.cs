using CQRS.Core.Events;

namespace CQRS.Core.Producers
{
    public interface IEventProducer
    {
        void Produce(string topic, BaseEvent @event);
    }
}