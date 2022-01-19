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

        public async Task<bool> CreateAsync(PostEntity post)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            context.Posts.Add(post);

            var result = await context.SaveChangesAsync().ConfigureAwait(false);
            return result > 0;
        }

        public async Task<List<PostEntity>> GetByAuthorAsync(string author)
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
                    .ConfigureAwait(false);
        }

        public async Task<List<PostEntity>> GetWithCommentsAsync()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.Posts
                    .Where(x => x.Comments != null && x.Comments.Any())
                    .ToListAsync()
                    .ConfigureAwait(false);
        }

        public async Task<List<PostEntity>> GetWithLikesAsync(int quantity)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.Posts
                    .Where(x => x.Likes > 0)
                    .ToListAsync()
                    .ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(Guid postId, PostEntity post)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            var persistedPost = await GetByIdAsync(postId);

            if (persistedPost == null) return false;

            context.Entry(persistedPost).CurrentValues.SetValues(post);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }
    }
}