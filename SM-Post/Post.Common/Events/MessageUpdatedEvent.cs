using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class MessageUpdatedEvent : BaseEvent
    {
        public MessageUpdatedEvent()
        {
        }

        public MessageUpdatedEvent(Guid id, int version, string message) : base(id, version)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}