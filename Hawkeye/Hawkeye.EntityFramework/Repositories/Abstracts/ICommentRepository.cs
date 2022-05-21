using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Contracts;

namespace Hawkeye.EntityFramework.Repositories.Abstracts
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> GetAllCommentsAsync();

    }
}
