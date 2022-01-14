namespace CQRS.Core.Messages
{
    public class Message
    {
        public Message(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}