using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Core;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Hawkeye.EntityFramework.Repositories
{
    public sealed class FilmRepository : Repository<Film>, IFilmRepository
    {
        public FilmRepository(HawkeyeDbContext context) : base(context)
        {
        }

        public async Task<Film> GetByNameAsync(string name)
        {
            var result = await Data.FirstOrDefaultAsync(f => f.Name == name); 
            return result;
        }
    }
}
