using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class PostRemovedEvent : BaseEvent
    {
        public PostRemovedEvent()
        {
        }

        public PostRemovedEvent(Guid id, int version) : base(id, version)
        {
        }
    }
}