using CQRS.Core.Commands;
using CQRS.Core.Messages;

namespace CQRS.Core.Infrastructure
{
    public interface ICommandDispatcher
    {
        void RegisterHandler<T>(Action<T> handler) where T : Message;
        void Send(BaseCommand command);
    }
}