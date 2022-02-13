using System.Text.Json;
using Confluent.Kafka;
using CQRS.Core.Consumers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Post.Common.Events;

namespace Post.Query.Infrastructure.Consumers
{
    public class ConsumerHostedService : IHostedService
    {
        private readonly ILogger<ConsumerHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ConsumerHostedService(ILogger<ConsumerHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Event Consumer Service running.");

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var eventConsumer = scope.ServiceProvider.GetRequiredService<IEventConsumer>();

                Task.Run(() => eventConsumer.ConsumeAsync<PostCreatedEvent>(nameof(PostCreatedEvent)), cancellationToken);
                Task.Run(() => eventConsumer.ConsumeAsync<MessageUpdatedEvent>(nameof(MessageUpdatedEvent)), cancellationToken);
                Task.Run(() => eventConsumer.ConsumeAsync<PostLikedEvent>(nameof(PostLikedEvent)), cancellationToken);
                Task.Run(() => eventConsumer.ConsumeAsync<CommentAddedEvent>(nameof(CommentAddedEvent)), cancellationToken);
                Task.Run(() => eventConsumer.ConsumeAsync<CommentUpdatedEvent>(nameof(CommentUpdatedEvent)), cancellationToken);
                Task.Run(() => eventConsumer.ConsumeAsync<CommentRemovedEvent>(nameof(CommentRemovedEvent)), cancellationToken);
                Task.Run(() => eventConsumer.ConsumeAsync<PostRemovedEvent>(nameof(PostRemovedEvent)), cancellationToken);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}