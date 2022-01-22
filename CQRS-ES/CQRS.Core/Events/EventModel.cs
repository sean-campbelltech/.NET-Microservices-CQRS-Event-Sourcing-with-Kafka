using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CQRS.Core.Events
{
    public class EventModel
    {
        public EventModel(
            string id,
            DateTime timeStamp,
            Guid aggregateIdentifier,
            string aggregateType,
            int version,
            string eventType,
            BaseEvent eventData)
        {
            Id = id;
            TimeStamp = timeStamp;
            AggregateIdentifier = aggregateIdentifier;
            AggregateType = aggregateType;
            Version = version;
            EventType = eventType;
            EventData = eventData;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid AggregateIdentifier { get; set; }
        public string AggregateType { get; set; }
        public int Version { get; set; }
        public string EventType { get; set; }
        public BaseEvent EventData { get; set; }
    }
}