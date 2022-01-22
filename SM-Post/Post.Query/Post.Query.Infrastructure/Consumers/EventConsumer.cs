using System.Reflection;
using Confluent.Kafka;
using CQRS.Core.Events;
using Microsoft.Extensions.Options;
using Post.Query.Infrastructure.Handlers;

namespace Post.Query.Infrastructure.Consumers
{
    public class EventConsumer : IEventConsumer
    {
        private readonly ConsumerConfig _config;
        private readonly IEventHandler _eventHandler;

        public EventConsumer(IOptions<ConsumerConfig> config, IEventHandler eventHandler)
        {
            _config = config.Value;
            _eventHandler = eventHandler;
        }

        public async Task ConsumeAsync<T>(string topic) where T : BaseEvent
        {
            using var consumer = new ConsumerBuilder<string, T>(_config).Build();
            consumer.Subscribe(topic);
            var cancelToken = new CancellationTokenSource();

            try
            {
                while (true)
                {
                    var consumeResult = consumer.Consume(cancelToken.Token);

                    if (consumeResult?.Message == null) continue;

                    var @event = consumeResult.Message.Value;
                    var handlerMethod = _eventHandler.GetType().GetMethod("On");

                    if (handlerMethod == null)
                    {
                        throw new ArgumentNullException(nameof(handlerMethod), "Could not find event handler method.");
                    }

                    await (Task)handlerMethod.Invoke(_eventHandler, new object[] { consumeResult.Message.Value });
                    consumer.Commit(consumeResult);
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
        }
    }
}
