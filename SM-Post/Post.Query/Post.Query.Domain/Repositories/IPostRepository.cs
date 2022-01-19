using Post.Query.Domain.Entities;

namespace Post.Query.Domain.Repositories
{
    public interface IPostRepository
    {
        Task CreateAsync(PostEntity post);
        Task UpdateAsync(Guid postId, PostEntity post);
        Task DeleteAsync(Guid postId);
        Task<PostEntity> GetByIdAsync(Guid postId);
        Task<List<PostEntity>> GetByAuthorAsync(string author);
        Task<List<PostEntity>> GetWithLikesAsync(int quantity);
        Task<List<PostEntity>> GetWithCommentsAsync();
    }
}