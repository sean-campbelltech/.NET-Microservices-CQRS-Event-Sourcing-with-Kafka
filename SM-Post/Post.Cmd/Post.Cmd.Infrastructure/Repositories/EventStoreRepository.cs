using CQRS.Core.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Post.Cmd.Domain.Entities;
using Post.Cmd.Infrastructure.Config;

namespace Post.Cmd.Infrastructure.Repositories
{
    public class EventStoreRepository : IEventStoreRepository<EventEntity>
    {
        private readonly IMongoCollection<EventEntity> _eventStoreCollection;

        public EventStoreRepository(IOptions<MongoDbConfig> config)
        {
            var mongoClient = new MongoClient(config.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(config.Value.Database);

            _eventStoreCollection = mongoDatabase.GetCollection<EventEntity>(config.Value.Collection);
        }

        public async Task<List<EventEntity>> FindAllAsync()
        {
            return await _eventStoreCollection.Find(_ => true).ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<EventEntity>> FindByAggregateId(Guid aggregateId)
        {
            return await _eventStoreCollection.Find(x => x.AggregateIdentifier == aggregateId).ToListAsync().ConfigureAwait(false);
        }

        public async Task SaveAsync(EventEntity @event)
        {
            await _eventStoreCollection.InsertOneAsync(@event);
        }
    }
}