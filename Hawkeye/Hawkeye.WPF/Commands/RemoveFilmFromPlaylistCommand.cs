using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.WPF.Models;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace Hawkeye.WPF.Commands
{
    public class RemoveFilmFromPlaylistCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly CurrentPlaylistViewModel _currentPlaylistViewModel;

        public RemoveFilmFromPlaylistCommand(CurrentPlaylistViewModel currentPlaylistViewModel, IAuthenticator authenticator, IPlaylistRepository playlistRepository, IFilmRepository filmRepository)
        {
            _currentPlaylistViewModel = currentPlaylistViewModel;
            _authenticator = authenticator;
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
            if(parameter != null)
            {
                var film =  await _filmRepository.GetByNameAsync(parameter as string);
                if (film != null)
                {
                    PlaylistStorage.Playlist.Films.Remove(film);
                    _currentPlaylistViewModel.Playlist.Remove(film);

                    await _playlistRepository.UpdateAsync(PlaylistStorage.Playlist);                    

                }
                else
                {
                    throw new Exception("Что-то пошло не так...");
                }
            }
        }

    }
}