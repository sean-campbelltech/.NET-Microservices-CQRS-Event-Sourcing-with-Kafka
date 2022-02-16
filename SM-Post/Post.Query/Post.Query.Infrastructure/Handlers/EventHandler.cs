using CQRS.Core.Events;
using Post.Common.Events;
using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;

namespace Post.Query.Infrastructure.Handlers
{
    public class EventHandler : IEventHandler
    {
        private readonly IPostRepository _postRepository;

        public EventHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task On(PostCreatedEvent @event)
        {
            var post = new PostEntity
            {
                PostId = @event.Id,
                Author = @event.Author,
                DatePosted = @event.DatePosted,
                Message = @event.Message
            };

            await _postRepository.CreateAsync(post);
        }

        private async Task<Tuple<Guid, PostEntity>> GetIdAndPostAsync(BaseEvent @event)
        {
            var postId = @event.Id;
            var post = await _postRepository.GetByIdAsync(postId);

            return new Tuple<Guid, PostEntity>(postId, post);
        }

        public async Task On(MessageUpdatedEvent @event)
        {
            var (postId, post) = await GetIdAndPostAsync(@event);

            if (post == null) return;

            post.Message = @event.Message;
            await _postRepository.UpdateAsync(postId, post);
        }

        public async Task On(PostLikedEvent @event)
        {
            var (postId, post) = await GetIdAndPostAsync(@event);

            if (post == null) return;

            post.Likes++;
            await _postRepository.UpdateAsync(postId, post);
        }

        public async Task On(CommentAddedEvent @event)
        {
            var (postId, post) = await GetIdAndPostAsync(@event);

            if (post == null) return;

            if (post.Comments?.Any() != true)
            {
                post.Comments = new List<CommentEntity>();
            }

            post.Comments.Add(new CommentEntity
            {
                PostId = postId,
                CommentId = @event.CommentId,
                CommentDate = @event.CommentDate,
                Comment = @event.Comment,
                Username = @event.Username,
                Edited = false
            });

            await _postRepository.UpdateAsync(postId, post);
        }

        public async Task On(CommentUpdatedEvent @event)
        {
            var (postId, post) = await GetIdAndPostAsync(@event);

            if (post?.Comments?.Any() != true) return;

            var comment = post.Comments.FirstOrDefault(x => x.CommentId == @event.CommentId);

            if (comment == null) return;

            var index = post.Comments.IndexOf(comment);
            post.Comments[index].Comment = @event.Comment;
            post.Comments[index].Edited = true;
            post.Comments[index].CommentDate = @event.EditDate;

            await _postRepository.UpdateAsync(postId, post);
        }

        public async Task On(CommentRemovedEvent @event)
        {
            var (postId, post) = await GetIdAndPostAsync(@event);

            if (post?.Comments?.Any() != true) return;

            var comment = post.Comments.FirstOrDefault(x => x.CommentId == @event.CommentId);

            if (comment == null) return;

            post.Comments.Remove(comment);

            await _postRepository.UpdateAsync(postId, post);
        }

        public async Task On(PostRemovedEvent @event)
        {
            await _postRepository.DeleteAsync(@event.Id);
        }
    }
}