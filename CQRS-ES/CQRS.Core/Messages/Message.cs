namespace CQRS.Core.Messages
{
    public class Message
    {
        protected Message(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}