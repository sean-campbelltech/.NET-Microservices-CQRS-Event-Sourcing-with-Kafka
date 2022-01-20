using System.ComponentModel.DataAnnotations;
using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class NewPostCommand : BaseCommand
    {
        public NewPostCommand()
        {
        }

        public NewPostCommand(Guid id, string author, string message) : base(id)
        {
            this.Author = author;
            this.Message = message;
        }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Message { get; set; }
    }
}