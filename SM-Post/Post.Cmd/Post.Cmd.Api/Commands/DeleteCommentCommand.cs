using System.ComponentModel.DataAnnotations;
using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class DeleteCommentCommand : BaseCommand
    {
        public DeleteCommentCommand()
        {
        }

        public DeleteCommentCommand(Guid id, Guid commentId, string username) : base(id)
        {
            this.CommentId = commentId;
            this.Username = username;
        }

        [Required]
        public Guid CommentId { get; set; }

        [Required]
        public string Username { get; set; }
    }
}