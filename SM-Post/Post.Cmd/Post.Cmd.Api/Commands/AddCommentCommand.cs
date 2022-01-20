using System.ComponentModel.DataAnnotations;
using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class AddCommentCommand : BaseCommand
    {
        public AddCommentCommand()
        {
        }

        public AddCommentCommand(Guid id, string comment, string username) : base(id)
        {
            this.Comment = comment;
            this.Username = username;
        }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string Username { get; set; }
    }
}