using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Contracts;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.WPF.Models;
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
    public class AddFilmToPlaylistCommand : ICommand
    {

        private readonly IPlaylistRepository _playlistRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly CurrentPlaylistViewModel _currentPlaylistViewModel;

        public AddFilmToPlaylistCommand(CurrentPlaylistViewModel currentPlaylistViewModel, IAuthenticator authenticator, IPlaylistRepository playlistRepository, IFilmRepository filmRepository)
        {
            _currentPlaylistViewModel = currentPlaylistViewModel;
            _playlistRepository = playlistRepository;
            _filmRepository = filmRepository;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                if (_currentPlaylistViewModel.AddFilmName != null)
                {
                    var film = await _filmRepository.GetByNameAsync(_currentPlaylistViewModel.AddFilmName);
                    if (film != null)
                    {
                        if(PlaylistStorage.Playlist.Films == null)
                        {
                            PlaylistStorage.Playlist.Films = new List<Film>();
                        }
                        PlaylistStorage.Playlist.Films.Add(film);
                        await _playlistRepository.UpdateAsync(PlaylistStorage.Playlist);
                        _currentPlaylistViewModel.Playlist.Add(film);
                        _currentPlaylistViewModel.AddFilmName = "Название фильма: ";
                    }
                    else
                    {
                        throw new Exception("Фильма с таким названием у нас нету");
                    }
                }
                else
                {
                    throw new Exception("Фильма с таким названием у нас нету");
                }
            }
            catch (Exception ex)
            {
                _currentPlaylistViewModel.ErrorMessage = ex.Message;
            }

        }
    }
}
