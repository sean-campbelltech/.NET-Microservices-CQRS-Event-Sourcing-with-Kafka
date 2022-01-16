using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class AddCommentCommand : BaseCommand
    {
        public AddCommentCommand()
        {
        }

        public AddCommentCommand(string id, string comment, string username) : base(id)
        {
            this.Comment = comment;
            this.Username = username;
        }

        public string Comment { get; set; }
        public string Username { get; set; }
    }
}