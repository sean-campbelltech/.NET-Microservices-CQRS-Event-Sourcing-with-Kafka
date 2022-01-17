namespace CQRS.Core.Messages
{
    public class Message
    {
        protected Message()
        {
        }

        protected Message(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}