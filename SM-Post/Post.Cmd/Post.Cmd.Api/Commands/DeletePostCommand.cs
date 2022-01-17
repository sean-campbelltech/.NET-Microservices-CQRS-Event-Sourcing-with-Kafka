using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class DeletePostCommand : BaseCommand
    {
        public DeletePostCommand()
        {
        }

        public DeletePostCommand(Guid id) : base(id)
        {
        }
    }
}