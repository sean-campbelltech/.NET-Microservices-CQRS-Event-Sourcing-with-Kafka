using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class PostLikedEvent : BaseEvent
    {
        public PostLikedEvent()
        {
        }

        public PostLikedEvent(string id) : base(id)
        {
        }
    }
}