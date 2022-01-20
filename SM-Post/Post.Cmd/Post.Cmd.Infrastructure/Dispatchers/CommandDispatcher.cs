using CQRS.Core.Commands;
using CQRS.Core.Infrastructure;

namespace Post.Cmd.Infrastructure.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Dictionary<Type, List<Func<BaseCommand, Task>>> _routes = new Dictionary<Type, List<Func<BaseCommand, Task>>>();

        public void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand
        {
            if (!_routes.TryGetValue(typeof(T), out List<Func<BaseCommand, Task>>? handlers))
            {
                handlers = new List<Func<BaseCommand, Task>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add(x => handler((T)x));
        }

        public Task Send(BaseCommand command)
        {
            if (_routes.TryGetValue(typeof(BaseCommand), out List<Func<BaseCommand, Task>>? handlers))
            {
                if (handlers?.Count != 1)
                    throw new IndexOutOfRangeException("Cannot send command to more than one handler!");

                handlers[0](command);
            }
            else
            {
                throw new ArgumentNullException(nameof(handlers), "No command handler registered!");
            }

            return Task.CompletedTask;
        }
    }
}