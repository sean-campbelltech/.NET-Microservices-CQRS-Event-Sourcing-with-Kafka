using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;

namespace Post.Query.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        public Task<bool> CreateAsync(PostEntity post)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostEntity>> GetByAuthorAsync(string author)
        {
            throw new NotImplementedException();
        }

        public Task<PostEntity> GetByIdAsync(string postId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostEntity>> GetWithComments()
        {
            throw new NotImplementedException();
        }

        public Task<List<PostEntity>> GetWithLikes(int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(string postId, PostEntity post)
        {
            throw new NotImplementedException();
        }
    }
}