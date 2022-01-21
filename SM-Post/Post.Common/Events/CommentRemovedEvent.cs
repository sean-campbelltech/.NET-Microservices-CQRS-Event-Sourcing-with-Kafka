using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class CommentRemovedEvent : BaseEvent
    {
        public CommentRemovedEvent()
        {
        }

        public CommentRemovedEvent(Guid id, int version, Guid commentId) : base(id, version)
        {
            this.CommentId = commentId;
        }

        public Guid CommentId { get; set; }
    }
}