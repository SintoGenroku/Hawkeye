using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hawkeye.WPF.Commands
{
    public class CreatePlaylistCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly PlaylistsViewModel _playlistsViewModel;
        private User _currentUser => _authenticator.CurrentUser;

        public CreatePlaylistCommand(PlaylistsViewModel playlistViewModel, IAuthenticator authenticator, IPlaylistRepository playlistRepository)
        {
            _playlistsViewModel = playlistViewModel;
            _authenticator = authenticator;
            _playlistRepository = playlistRepository;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                if (_playlistsViewModel.NewPlaylistName.Replace(" ","") != "")
                {
                    var playlist = new Playlist()
                    {
                        Name = _playlistsViewModel.NewPlaylistName,
                        User = _currentUser,
                        Films = new List<Film>()
                    };
                    _playlistRepository.CreateAsync(playlist);
                    _playlistsViewModel.Playlists.Add(playlist);
                    _playlistsViewModel.NewPlaylistName = "";
                    _playlistsViewModel.ErrorMessage = "";
                }
                else
                {
                    throw new Exception("Введите навзвание плейлиста, чтобы его создать");
                }
            }
            catch (Exception ex)
            {
                _playlistsViewModel.ErrorMessage = ex.Message;
            }

        }
    }
}
