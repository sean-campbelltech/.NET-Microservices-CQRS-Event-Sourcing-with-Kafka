using CQRS.Core.Events;

namespace Post.Common.Events
{
    public class PostCreatedEvent : BaseEvent
    {
        public PostCreatedEvent()
        {
        }

        public PostCreatedEvent(Guid id, int version, string author, string messsage, DateTime datePosted) : base(id, version)
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