using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Contracts;

namespace Hawkeye.EntityFramework.Repositories.Abstracts
{
    public interface IUserRepository : IRepository<User>
    {

        Task<User> GetByNameAsync(string name);
    }
}
