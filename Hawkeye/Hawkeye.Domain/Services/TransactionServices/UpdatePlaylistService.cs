using Hawkeye.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.Domain.Services.TransactionServices
{
    public class UpdatePlaylistService : IUpdatePlaylistService
    {
        private readonly IDataService<Playlist> _playlistService;

        public UpdatePlaylistService(IDataService<Playlist> playlistService)
        {
            _playlistService = playlistService;
        }

        public async Task<Playlist> InsertFilm(Playlist playlist, Film film)
        {
            if (film != null)
            {
                playlist.Films.Add(film);
            }
            await _playlistService.Update(playlist.Id, playlist);
            return playlist;
        }

        public async Task<Playlist> RemoveFilm(Playlist playlist, Film film)
        {
            if (film != null)
            {
                playlist.Films.Remove(film);
            }
            await _playlistService.Update(playlist.Id, playlist);
            return playlist;
        }
    }
}
