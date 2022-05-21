using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Core;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Hawkeye.EntityFramework.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(HawkeyeDbContext context) : base(context)
        {
        }

        public List<Comment> GetAllCommentsAsync()
        {
            var result = Data.Include(comment => comment.User).Include(comment => comment.Film).ToList();
            return result;
        }

    }
}
