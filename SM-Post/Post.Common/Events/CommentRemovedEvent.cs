using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class CommentRemovedEvent : BaseEvent
    {
        public CommentRemovedEvent()
        {
        }

        public CommentRemovedEvent(Guid id, int commentIndex) : base(id)
        {
            this.CommentIndex = commentIndex;
        }

        public int CommentIndex { get; set; }
    }
}