using CQRS.Core.Domain;
using Post.Common.Events;

namespace Post.Cmd.Domain.Aggregates
{
    public class PostAggregate : AggregateRoot
    {
        private bool _active;
        private readonly List<Tuple<string, string>> _comments = new List<Tuple<string, string>>();

        public bool Active { get => _active; set => _active = value; }

        public PostAggregate()
        {
        }

        public PostAggregate(Guid id, string author, string message)
        {
            RaiseEvent(new PostCreatedEvent
            {
                Id = id,
                Author = author,
                Message = message,
                DatePosted = DateTime.Now
            });
        }

        public void Apply(PostCreatedEvent @event)
        {
            _id = @event.Id;
            _active = true;
        }

        public void EditMessage(string message)
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot edit the message of an inactive post.");
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new InvalidOperationException($"The value of {message} cannot be null or empty. Please provide a valid message.");
            }

            RaiseEvent(new MessageUpdatedEvent
            {
                Id = _id,
                Message = message
            });
        }

        public void Apply(MessageUpdatedEvent @event)
        {
            _id = @event.Id;
        }

        public void LikePost()
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot like an inactive post.");
            }

            RaiseEvent(new PostLikedEvent
            {
                Id = _id
            });
        }

        public void Apply(PostLikedEvent @event)
        {
            _id = @event.Id;
        }

        public void AddComment(string comment, string username)
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot add a comment to an inactive post.");
            }

            RaiseEvent(new CommentAddedEvent
            {
                Id = _id,
                Comment = comment,
                Username = username,
                CommentDate = DateTime.Now
            });
        }

        public void Apply(CommentAddedEvent @event)
        {
            _id = @event.Id;
            _comments.Add(new Tuple<string, string>(@event.Comment, @event.Username));
        }

        public void EditComment(int index, string comment, string username)
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot edit a comment of an inactive post.");
            }

            if ((index + 1) > _comments.Count)
            {
                throw new InvalidCastException($"The post does not have a comment at index {index}.");
            }

            if (_comments[index].Item2.Equals(username, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new InvalidCastException("You are not allowed to edit the comment of another user.");
            }

            RaiseEvent(new CommentUpdatedEvent
            {
                Id = _id,
                CommentIndex = index,
                Comment = comment,
                Username = username,
                EditDate = DateTime.Now
            });
        }

        public void Apply(CommentUpdatedEvent @event)
        {
            _id = @event.Id;
            _comments[@event.CommentIndex] = new Tuple<string, string>(@event.Comment, @event.Username);
        }

        public void DeleteComment(int index, string username)
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot delete a comment of an inactive post.");
            }

            if ((index + 1) > _comments.Count)
            {
                throw new InvalidOperationException($"The post does not have a comment at index {index}.");
            }

            if (_comments[index].Item2.Equals(username, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new InvalidOperationException("You are not allowed to delete a comment of another user.");
            }

            RaiseEvent(new CommentRemovedEvent
            {
                Id = _id,
                CommentIndex = index
            });
        }

        public void Apply(CommentRemovedEvent @event)
        {
            _id = @event.Id;
            _comments.RemoveAt(@event.CommentIndex);
        }

        public void DeletePost()
        {
            if (!_active)
            {
                throw new InvalidOperationException("The post has already been removed.");
            }

            RaiseEvent(new PostRemovedEvent { Id = _id });
        }

        public void Apply(PostRemovedEvent @event)
        {
            _id = @event.Id;
            _active = false;
        }
    }
}