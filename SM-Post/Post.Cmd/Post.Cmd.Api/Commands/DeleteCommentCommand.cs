using System.ComponentModel.DataAnnotations;
using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class DeleteCommentCommand : BaseCommand
    {
        public DeleteCommentCommand()
        {
        }

        public DeleteCommentCommand(Guid id, int commentIndex, string username) : base(id)
        {
            this.CommentIndex = commentIndex;
            this.Username = username;
        }

        [Required]
        public int CommentIndex { get; set; }

        [Required]
        public string Username { get; set; }
    }
}