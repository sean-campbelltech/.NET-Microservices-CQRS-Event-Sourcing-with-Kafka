using Confluent.Kafka;
using CQRS.Core.Events;
using CQRS.Core.Producers;
using Microsoft.Extensions.Options;

namespace Post.Cmd.Infrastructure.Producers
{
    public class EventProducer : IEventProducer
    {
        private readonly ProducerConfig _config;
        private readonly ISerializer<BaseEvent> _serializer;

        public EventProducer(IOptions<ProducerConfig> config, ISerializer<BaseEvent> serializer)
        {
            _config = config.Value;
            _serializer = serializer;
        }

        public async Task ProduceAsync<T>(string topic, T @event) where T : BaseEvent
        {
            using var producer = new ProducerBuilder<string, T>(_config)
                    .SetKeySerializer(Serializers.Utf8)
                    .SetValueSerializer(new JsonSerializer<T>())
                    .Build();

            var eventMessage = new Message<string, T>
            {
                Key = Guid.NewGuid().ToString(),
                Value = @event
            };

            var deliveryResult = await producer.ProduceAsync(topic, eventMessage);

            if (deliveryResult.Status == PersistenceStatus.NotPersisted)
            {
                throw new Exception($"Could not produce {@event.GetType().Name} message to topic - {topic} due to the following reason: {deliveryResult.Message}!");
            }
        }
    }
}