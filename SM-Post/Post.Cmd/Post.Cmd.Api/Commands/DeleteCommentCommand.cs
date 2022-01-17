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

        public int CommentIndex { get; set; }
        public string Username { get; set; }
    }
}