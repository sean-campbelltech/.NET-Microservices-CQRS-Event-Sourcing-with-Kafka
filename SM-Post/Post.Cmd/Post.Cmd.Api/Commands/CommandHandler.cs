using CQRS.Core.Handlers;
using Post.Cmd.Domain.Aggregates;

namespace Post.Cmd.Api.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

        public CommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
        {
            _eventSourcingHandler = eventSourcingHandler;
        }

        public void Handle(NewPostCommand command)
        {
            var aggregate = new PostAggregate(command.Id, command.Author, command.Message);

            _eventSourcingHandler.Save(aggregate);
        }

        public void Handle(EditMessageCommand command)
        {
            var aggregate = _eventSourcingHandler.GetById(command.Id);
            aggregate.EditMessage(command.Message);

            _eventSourcingHandler.Save(aggregate);
        }

        public void Handle(LikePostCommand command)
        {
            var aggregate = _eventSourcingHandler.GetById(command.Id);
            aggregate.LikePost();

            _eventSourcingHandler.Save(aggregate);
        }

        public void Handle(AddCommentCommand command)
        {
            var aggregate = _eventSourcingHandler.GetById(command.Id);
            aggregate.AddComment(command.Comment, command.Username);

            _eventSourcingHandler.Save(aggregate);
        }

        public void Handle(EditCommentCommand command)
        {
            var aggregate = _eventSourcingHandler.GetById(command.Id);
            aggregate.EditComment(command.CommentIndex, command.Comment, command.Username);

            _eventSourcingHandler.Save(aggregate);
        }

        public void Handle(DeleteCommentCommand command)
        {
            var aggregate = _eventSourcingHandler.GetById(command.Id);
            aggregate.DeleteComment(command.CommentIndex, command.Username);

            _eventSourcingHandler.Save(aggregate);
        }

        public void Handle(DeletePostCommand command)
        {
            var aggregate = _eventSourcingHandler.GetById(command.Id);
            aggregate.DeletePost();

            _eventSourcingHandler.Save(aggregate);
        }
    }
}