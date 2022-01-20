using System.ComponentModel.DataAnnotations;
using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class EditCommentCommand : BaseCommand
    {
        public EditCommentCommand()
        {
        }

        public EditCommentCommand(Guid id, int commentIndex, string comment, string username) : base(id)
        {
            this.CommentIndex = commentIndex;
            this.Comment = comment;
            this.Username = username;
        }

        [Required]
        public int CommentIndex { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string Username { get; set; }
    }
}