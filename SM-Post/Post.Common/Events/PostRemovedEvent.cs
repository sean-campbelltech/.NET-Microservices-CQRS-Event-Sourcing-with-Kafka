using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class PostRemovedEvent : BaseEvent
    {
        public PostRemovedEvent()
        {
        }

        public PostRemovedEvent(Guid id) : base(id)
        {
        }
    }
}