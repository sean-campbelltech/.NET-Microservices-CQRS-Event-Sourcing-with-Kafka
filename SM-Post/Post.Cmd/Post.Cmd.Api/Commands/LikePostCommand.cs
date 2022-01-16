using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class LikePostCommand : BaseCommand
    {
        public LikePostCommand(string id) : base(id)
        {
        }
    }
}