using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class CommentAddedEvent : BaseEvent
    {
        public CommentAddedEvent()
        {
        }

        public CommentAddedEvent(string id, string comment, string username, DateTime commentDate) : base(id)
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