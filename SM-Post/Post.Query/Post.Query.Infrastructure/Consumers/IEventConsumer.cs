using CQRS.Core.Events;

namespace Post.Query.Infrastructure.Consumers
{
    public interface IEventConsumer
    {
        Task ConsumeAsync<T>(string topic) where T : BaseEvent;
    }
}