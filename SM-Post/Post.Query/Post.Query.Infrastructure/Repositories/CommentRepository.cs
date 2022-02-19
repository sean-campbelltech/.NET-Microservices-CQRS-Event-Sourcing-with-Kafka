using Microsoft.EntityFrameworkCore;
using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;
using Post.Query.Infrastructure.DataAccess;

namespace Post.Query.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseContext _context;

        public CommentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<CommentEntity> GetByIdAsync(Guid commentId)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);
        }

        public async Task UpdateAsync(CommentEntity comment)
        {
            _context.Comments.Update(comment);
            _ = await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid commentId)
        {
            var comment = await GetByIdAsync(commentId);

            if (commentId == null) return;

            _context.Comments.Remove(comment);
            _ = await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(CommentEntity comment)
        {
            _context.Comments.Add(comment);
            _ = await _context.SaveChangesAsync();
        }
    }
}