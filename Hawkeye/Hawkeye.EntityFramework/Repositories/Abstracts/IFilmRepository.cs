using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Contracts;

namespace Hawkeye.EntityFramework.Repositories.Abstracts
{
    public interface IFilmRepository : IRepository<Film>
    {
        Task<Film> GetByNameAsync(string name);
        IQueryable<Film> GetByIdWithCommentsAsync();

    }
}
