using Microsoft.EntityFrameworkCore;
using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;
using Post.Query.Infrastructure.DataAccess;

namespace Post.Query.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseContextFactory _contextFactory;

        public PostRepository(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateAsync(PostEntity post)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            context.Posts.Add(post);

            _ = await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid postId)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            var post = await GetByIdAsync(postId);

            if (post == null) return;

            context.Posts.Remove(post);
            _ = await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<PostEntity>> ListByAuthorAsync(string author)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.Posts
                    .Where(x => x.Author.Equals(author))
                    .ToListAsync()
                    .ConfigureAwait(false);
        }

        public async Task<PostEntity> GetByIdAsync(Guid postId)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.Posts
                    .Where(x => x.PostId == postId)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false) ?? null;
        }

        public async Task<List<PostEntity>> ListAllAsync()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.Posts.ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<PostEntity>> ListWithCommentsAsync()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.Posts
                    .Where(x => x.Comments != null && x.Comments.Any())
                    .ToListAsync()
                    .ConfigureAwait(false);
        }

        public async Task<List<PostEntity>> ListWithLikesAsync(int quantity)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.Posts
                    .Where(x => x.Likes > 0)
                    .ToListAsync()
                    .ConfigureAwait(false);
        }

        public async Task UpdateAsync(Guid postId, PostEntity post)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            var persistedPost = await GetByIdAsync(postId);

            if (persistedPost == null) return;

            context.Entry(persistedPost).CurrentValues.SetValues(post);
            _ = await context.SaveChangesAsync();
        }
    }
}