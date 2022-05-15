using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.WPF.Commands;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hawkeye.WPF.ViewModels
{
    public class PlaylistsViewModel : ViewModelBase
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IAuthenticator _authenticator;

        public ObservableCollection<Playlist> Playlists { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public PlaylistsViewModel(IPlaylistRepository playlistRepository, INavigator navigator, IViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _playlistRepository = playlistRepository;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);

            Playlists = new ObservableCollection<Playlist>();
            RefreshPlaylists();            
        }

        public void RefreshPlaylists()
        {
            Playlists.Clear();
            var data = _playlistRepository.GetByIdWithOwnerAsync(_authenticator.CurrentUser.Id);
            foreach (var item in data)
            {
                Playlists.Add(item);
            }
        }
    }
}
