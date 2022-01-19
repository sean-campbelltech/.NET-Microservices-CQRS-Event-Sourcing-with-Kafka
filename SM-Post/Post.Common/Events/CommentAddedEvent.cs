using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class CommentAddedEvent : BaseEvent
    {
        public CommentAddedEvent()
        {
        }

        public CommentAddedEvent(Guid id, int version, string comment, string username, DateTime commentDate) : base(id, version)
        {
            this.Comment = comment;
            this.Username = username;
            this.CommentDate = commentDate;
        }

        public string Comment { get; set; }
        public string Username { get; set; }
        public DateTime CommentDate { get; set; }
    }
}