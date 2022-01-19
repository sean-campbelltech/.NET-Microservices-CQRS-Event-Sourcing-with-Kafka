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
                CommentId = Guid.NewGuid(),
                Username = @event.Username,
                CommentDate = @event.CommentDate,
                Comment = @event.Comment,
                Edited = false
            });

            await _postRepository.UpdateAsync(postId, post);
        }

        public async Task On(CommentUpdatedEvent @event)
        {
            var (postId, post) = await GetIdAndPostAsync(@event);

            if (post == null) return;

            post.Comments[@event.CommentIndex].Comment = @event.Comment;
            post.Comments[@event.CommentIndex].Edited = true;
            post.Comments[@event.CommentIndex].CommentDate = @event.EditDate;

            await _postRepository.UpdateAsync(postId, post);
        }

        public async Task On(CommentRemovedEvent @event)
        {
            var (postId, post) = await GetIdAndPostAsync(@event);

            if (post == null) return;

            post.Comments.RemoveAt(@event.CommentIndex);

            await _postRepository.UpdateAsync(postId, post);
        }

        public async Task On(PostRemovedEvent @event)
        {
            await _postRepository.DeleteAsync(@event.Id);
        }
    }
}