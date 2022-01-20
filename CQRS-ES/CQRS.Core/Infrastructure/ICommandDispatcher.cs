using CQRS.Core.Commands;

namespace CQRS.Core.Infrastructure
{
    public interface ICommandDispatcher
    {
        void RegisterHandler<T>(Action<T> handler) where T : BaseCommand;
        void Send(BaseCommand command);
    }
}