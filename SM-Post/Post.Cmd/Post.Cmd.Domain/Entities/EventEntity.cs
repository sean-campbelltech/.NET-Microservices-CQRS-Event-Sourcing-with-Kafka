using CQRS.Core.Events;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Post.Cmd.Domain.Entities
{
    public class EventEntity : BaseEventEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public override string Id { get; set; }
    }
}