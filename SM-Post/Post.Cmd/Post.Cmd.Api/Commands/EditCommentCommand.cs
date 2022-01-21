using System.ComponentModel.DataAnnotations;
using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class EditCommentCommand : BaseCommand
    {
        public EditCommentCommand()
        {
        }

        public EditCommentCommand(Guid id, Guid commentIndex, string comment, string username) : base(id)
        {
            this.CommentId = commentIndex;
            this.Comment = comment;
            this.Username = username;
        }

        [Required]
        public Guid CommentId { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string Username { get; set; }
    }
}