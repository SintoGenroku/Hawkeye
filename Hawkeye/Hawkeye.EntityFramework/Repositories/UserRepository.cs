using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Core;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Hawkeye.EntityFramework.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HawkeyeDbContext context) : base(context)
        {
        }

        public Task<User> GetByNameAsync(string name)
        {
            var result = Data.FirstOrDefaultAsync(x => x.Name == name);
            return result;
        }
        public IQueryable<User> GetByNameWithFaforiteAsync()
        {
            var result = Data.Include(user => user.FavoriteFilms);
            return result;
        }
    }
}