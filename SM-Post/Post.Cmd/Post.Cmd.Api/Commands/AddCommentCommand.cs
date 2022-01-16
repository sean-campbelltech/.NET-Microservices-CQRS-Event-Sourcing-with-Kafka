using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class AddCommentCommand : BaseCommand
    {
        public AddCommentCommand(string id, string comment) : base(id)
        {
            this.Comment = comment;
        }

        public string Comment;
    }
}