using CQRS.Core.Messages;

namespace CQRS.Core.Commands
{
    public abstract class BaseCommand : Message
    {
        protected BaseCommand()
        {
        }

        protected BaseCommand(string id) : base(id)
        {
        }
    }
}