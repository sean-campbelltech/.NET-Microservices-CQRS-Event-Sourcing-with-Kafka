using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class DeletePostCommand : BaseCommand
    {
        public DeletePostCommand(string id) : base(id)
        {
        }
    }
}