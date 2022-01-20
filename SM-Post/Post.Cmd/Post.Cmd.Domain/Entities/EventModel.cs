using CQRS.Core.Events;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Post.Cmd.Domain.Entities
{
    public class EventModel : BaseEventModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public override string Id { get; set; }
    }
}