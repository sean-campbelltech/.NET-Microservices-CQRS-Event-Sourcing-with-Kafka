using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class LikePostCommand : BaseCommand
    {
        public LikePostCommand()
        {
        }

        public LikePostCommand(Guid id) : base(id)
        {
        }
    }
}