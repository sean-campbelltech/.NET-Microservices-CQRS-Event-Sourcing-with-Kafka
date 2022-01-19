using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class PostLikedEvent : BaseEvent
    {
        public PostLikedEvent()
        {
        }

        public PostLikedEvent(Guid id, int version) : base(id, version)
        {
        }
    }
}