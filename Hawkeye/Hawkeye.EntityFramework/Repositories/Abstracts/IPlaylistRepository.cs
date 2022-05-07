using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Contracts;

namespace Hawkeye.EntityFramework.Repositories.Abstracts
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<Playlist> GetByNameAsync(string name, Guid userId);
    }
}
