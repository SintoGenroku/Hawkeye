using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Core;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Hawkeye.EntityFramework.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(HawkeyeDbContext context) : base(context)
        {
        }

        public Task<Role> GetByNameAsync(string name)
        {
            var result = Data.FirstOrDefaultAsync(x => x.Name == name);
            return result;
        }
    }
}
