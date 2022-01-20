using System.ComponentModel.DataAnnotations;

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

        [Required]
        public Guid Id { get; set; }
    }
}