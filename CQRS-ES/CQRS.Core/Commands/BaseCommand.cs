using CQRS.Core.Messages;

namespace CQRS.Core.Commands
{
    public abstract class BaseCommand : Message
    {
        protected BaseCommand()
        {
        }

        protected BaseCommand(Guid id) : base(id)
        {
        }
    }
}