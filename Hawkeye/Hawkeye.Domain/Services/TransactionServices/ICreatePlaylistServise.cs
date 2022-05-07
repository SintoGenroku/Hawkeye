using Hawkeye.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.Domain.Services.TransactionServices
{
    public interface ICreatePlaylistServise
    {
        public Task<Playlist> CreatePlaylist(User user, string name, ObservableCollection<Film> films = null);
    }
}
