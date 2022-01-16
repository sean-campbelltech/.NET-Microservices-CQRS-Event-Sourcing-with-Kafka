using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class PostCreatedEvent : BaseEvent
    {
        public PostCreatedEvent()
        {
        }

        public PostCreatedEvent(string id, string author, string messsage, DateTime datePosted) : base(id)
        {
            this.Author = author;
            this.Message = messsage;
            this.DatePosted = datePosted;
        }

        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime DatePosted { get; set; }
    }
}