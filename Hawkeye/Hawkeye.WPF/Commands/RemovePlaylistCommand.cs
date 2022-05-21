using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.WPF.Models;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace Hawkeye.WPF.Commands
{
    public class RemovePlaylistCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly PlaylistsViewModel _PlaylistsViewModel;

        public RemovePlaylistCommand(PlaylistsViewModel PlaylistsViewModel, IPlaylistRepository playlistRepository)
        {
            _PlaylistsViewModel = PlaylistsViewModel;
            _playlistRepository = playlistRepository;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                var playlist = _playlistRepository.FindByIdAsync((Guid)parameter).Result;
                if (playlist != null)
                {
                    
                    _playlistRepository.DeleteAsync(playlist);
                    _PlaylistsViewModel.Playlists.Remove(playlist);
                }
                else
                {
                    throw new Exception("Что-то пошло не так...");
                }
            }
        }

    }
}
