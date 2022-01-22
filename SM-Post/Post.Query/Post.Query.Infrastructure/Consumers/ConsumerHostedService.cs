using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Post.Common.Events;

namespace Post.Query.Infrastructure.Consumers
{
    public class ConsumerHostedService : IHostedService
    {
        private readonly ILogger<ConsumerHostedService> _logger;
        private readonly IEventConsumer _eventConsumer;

        public ConsumerHostedService(ILogger<ConsumerHostedService> logger, IEventConsumer eventConsumer)
        {
            _logger = logger;
            _eventConsumer = eventConsumer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Event Consumer Service running.");

            Task.Run(() => _eventConsumer.ConsumeAsync<PostCreatedEvent>(nameof(_eventConsumer)), cancellationToken);
            Task.Run(() => _eventConsumer.ConsumeAsync<MessageUpdatedEvent>(nameof(_eventConsumer)), cancellationToken);
            Task.Run(() => _eventConsumer.ConsumeAsync<PostLikedEvent>(nameof(_eventConsumer)), cancellationToken);
            Task.Run(() => _eventConsumer.ConsumeAsync<CommentAddedEvent>(nameof(_eventConsumer)), cancellationToken);
            Task.Run(() => _eventConsumer.ConsumeAsync<CommentUpdatedEvent>(nameof(_eventConsumer)), cancellationToken);
            Task.Run(() => _eventConsumer.ConsumeAsync<CommentRemovedEvent>(nameof(_eventConsumer)), cancellationToken);
            Task.Run(() => _eventConsumer.ConsumeAsync<PostRemovedEvent>(nameof(_eventConsumer)), cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}