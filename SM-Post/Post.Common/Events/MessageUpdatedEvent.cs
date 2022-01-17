using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class MessageUpdatedEvent : BaseEvent
    {
        public MessageUpdatedEvent()
        {
        }

        public MessageUpdatedEvent(Guid id, string message) : base(id)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}