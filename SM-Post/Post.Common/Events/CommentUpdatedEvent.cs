using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class CommentUpdatedEvent : BaseEvent
    {
        public CommentUpdatedEvent()
        {
        }

        public CommentUpdatedEvent(Guid id, int version, Guid commentId, string comment, string username, DateTime editDate) : base(id, version)
        {
            this.CommentId = commentId;
            this.Comment = comment;
            this.Username = username;
            this.EditDate = editDate;
        }

        public Guid CommentId { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
        public DateTime EditDate { get; set; }
    }
}