using CQRS.Core.Events;

namespace CQRS.Core.Consumers
{
    public interface IEventConsumer
    {
        Task ConsumeAsync<T>(string topic) where T : BaseEvent;
    }
}