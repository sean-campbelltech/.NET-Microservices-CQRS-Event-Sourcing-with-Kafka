namespace Post.Cmd.Api.Commands
{
    public interface ICommandHandler
    {
        void Handle(NewPostCommand command);
        void Handle(EditMessageCommand command);
        void Handle(LikePostCommand command);
        void Handle(AddCommentCommand command);
        void Handle(EditCommentCommand command);
        void Handle(DeleteCommentCommand comment);
        void Handle(DeletePostCommand command);
    }
}