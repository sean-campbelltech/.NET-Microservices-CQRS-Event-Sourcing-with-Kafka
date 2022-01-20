using CQRS.Core.Commands;
using CQRS.Core.Infrastructure;

namespace Post.Cmd.Infrastructure.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Dictionary<Type, List<Action<BaseCommand>>> _routes = new Dictionary<Type, List<Action<BaseCommand>>>();

        public void RegisterHandler<T>(Action<T> handler) where T : BaseCommand
        {
            if (!_routes.TryGetValue(typeof(T), out List<Action<BaseCommand>>? handlers))
            {
                handlers = new List<Action<BaseCommand>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add(x => handler((T)x));
        }

        public void Send(BaseCommand command)
        {
            if (_routes.TryGetValue(typeof(BaseCommand), out List<Action<BaseCommand>>? handlers))
            {
                if (handlers?.Count != 1)
                    throw new IndexOutOfRangeException("Cannot send command to more than one handler!");

                handlers[0](command);
            }
            else
            {
                throw new ArgumentNullException("No command handler registered!");
            }
        }
    }
}