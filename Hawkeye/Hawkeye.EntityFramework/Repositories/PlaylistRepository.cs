using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Core;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Hawkeye.EntityFramework.Repositories
{
    public sealed class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(HawkeyeDbContext context) : base(context)
        {
        }

        public async Task<Playlist> GetByNameAsync(string name, Guid userId)
        {
            var result = await Data.FirstOrDefaultAsync(p => p.Name == name & p.User.Id == userId);
            return result;
        }

        public IQueryable<Playlist> GetByIdWithOwnerAsync(Guid id)
        {
            return Data.Where(playlist => playlist.User.Id == id).Include(playlist => playlist.Films);

        }
    }
}
