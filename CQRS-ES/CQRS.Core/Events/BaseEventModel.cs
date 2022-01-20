namespace CQRS.Core.Events
{
    public abstract class BaseEventModel
    {
        public virtual string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid AggregateIdentifier { get; set; }
        public string AggregateType { get; set; }
        public int Version { get; set; }
        public string EventType { get; set; }
        public BaseEvent EventData { get; set; }
    }
}