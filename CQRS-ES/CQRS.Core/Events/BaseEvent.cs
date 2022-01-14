using CQRS.Core.Messages;

namespace CQRS.Core.Events
{
    public abstract class BaseEvent : Message
    {
        public BaseEvent(string id) : base(id)
        {
        }
    }
}