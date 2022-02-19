using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;
using Post.Query.Infrastructure.DataAccess;

namespace Post.Query.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseContext _context;

        public PostRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PostEntity post)
        {
            _context.Posts.Add(post);
            _ = await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid postId)
        {
            var post = await GetByIdAsync(postId);

            if (post == null) return;

            _context.Posts.Remove(post);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<PostEntity>> ListByAuthorAsync(string author)
        {
            return await _context.Posts.AsNoTracking()
                    .Include(i => i.Comments).AsNoTracking()
                    .Where(x => x.Author.Equals(author))
                    .ToListAsync();
        }

        public async Task<PostEntity> GetByIdAsync(Guid postId)
        {
            return await _context.Posts
                    .Include(i => i.Comments)
                    .FirstOrDefaultAsync(x => x.PostId == postId);
        }

        public async Task<List<PostEntity>> ListAllAsync()
        {
            return await _context.Posts
                    .Include(i => i.Comments)
                    .ToListAsync();
        }

        public async Task<List<PostEntity>> ListWithCommentsAsync()
        {
            return await _context.Posts.AsNoTracking()
                    .Include(i => i.Comments).AsNoTracking()
                    .Where(x => x.Comments != null && x.Comments.Any())
                    .ToListAsync();
        }

        public async Task<List<PostEntity>> ListWithLikesAsync(int quantity)
        {
            return await _context.Posts.AsNoTracking()
                    .Include(i => i.Comments).AsNoTracking()
                    .Where(x => x.Likes > 0)
                    .ToListAsync();
        }

        public async Task UpdateAsync(PostEntity post)
        {
            _context.Posts.Update(post);
            _ = await _context.SaveChangesAsync();
        }
    }
}