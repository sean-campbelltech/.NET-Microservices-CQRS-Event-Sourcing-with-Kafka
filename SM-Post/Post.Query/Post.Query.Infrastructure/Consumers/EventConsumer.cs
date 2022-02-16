using System.Text.Json;
using Confluent.Kafka;
using CQRS.Core.Consumers;
using CQRS.Core.Events;
using Microsoft.Extensions.Options;
using Post.Query.Infrastructure.Handlers;

namespace Post.Query.Infrastructure.Consumers
{
    public class EventConsumer : IEventConsumer
    {
        private readonly ConsumerConfig _config;
        private readonly IEventHandler _eventHandler;

        public EventConsumer(
            IOptions<ConsumerConfig> config,
            IEventHandler eventHandler)
        {
            _config = config.Value;
            _eventHandler = eventHandler;
        }

        public void Consume<T>(string topic) where T : BaseEvent
        {
            using var consumer = new ConsumerBuilder<string, string>(_config)
                    .SetKeyDeserializer(Deserializers.Utf8)
                    .SetValueDeserializer(Deserializers.Utf8)
                    .Build();

            consumer.Subscribe(topic);
            var cancelToken = new CancellationTokenSource();

            try
            {
                while (true)
                {
                    var consumeResult = consumer.Consume(cancelToken.Token);

                    if (consumeResult?.Message == null) continue;

                    var @event = JsonSerializer.Deserialize(consumeResult.Message.Value, typeof(T));
                    var handlerMethod = _eventHandler.GetType().GetMethod("On", new Type[] { @event.GetType() });

                    if (handlerMethod == null)
                    {
                        throw new ArgumentNullException(nameof(handlerMethod), "Could not find event handler method.");
                    }

                    handlerMethod.Invoke(_eventHandler, new object[] { @event });
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
