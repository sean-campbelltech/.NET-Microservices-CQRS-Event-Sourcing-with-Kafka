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

        public int CommentIndex { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
    }
}