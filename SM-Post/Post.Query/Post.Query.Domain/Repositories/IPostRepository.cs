using Post.Query.Domain.Entities;

namespace Post.Query.Domain.Repositories
{
    public interface IPostRepository
    {
        Task<bool> CreateAsync(PostEntity post);
        Task<bool> UpdateAsync(string postId, PostEntity post);
        Task<PostEntity> GetByIdAsync(string postId);
        Task<List<PostEntity>> GetByAuthorAsync(string author);
        Task<List<PostEntity>> GetWithLikesAsync(int quantity);
        Task<List<PostEntity>> GetWithCommentsAsync();
    }
}