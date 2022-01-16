using CQRS.Core.Messages;

namespace CQRS.Core.Events
{
    public abstract class BaseEvent : Message
    {
        protected BaseEvent()
        {
        }

        protected BaseEvent(string id) : base(id)
        {
        }
    }
}