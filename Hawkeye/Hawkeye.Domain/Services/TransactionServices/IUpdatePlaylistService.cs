using Hawkeye.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.Domain.Services.TransactionServices
{
    public interface IUpdatePlaylistService
    {
        public Task<Playlist> InsertFilm(Playlist playlist, Film film);
        public Task<Playlist> RemoveFilm(Playlist playlist, Film film);
    }
}
