using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands
{
    public class EditMessageCommand : BaseCommand
    {
        public EditMessageCommand()
        {
        }

        public EditMessageCommand(Guid id, string message) : base(id)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}