using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.WPF.Commands;
using Hawkeye.WPF.Models;
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
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand CreatePlaylistCommand { get; }
        public ICommand RemovePlaylistCommand { get; }

        public ObservableCollection<Playlist> Playlists { get; set; }
        private Playlist _selectedPlaylist;
        public Playlist SelectedPlaylist 
        { 
            get { return _selectedPlaylist; }
            set 
            {
                _selectedPlaylist = value;
                PlaylistStorage.Playlist = value;
                OnPropertyChanged();
                UpdateCurrentViewModelCommand.Execute(ViewType.CurrentPlaylist);
                OnPropertyChanged(nameof(_navigator.CurrentViewModel));
            }
        }
        public string NewPlaylistName { get; set; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public PlaylistsViewModel(IPlaylistRepository playlistRepository, INavigator navigator, IViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _playlistRepository = playlistRepository;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            ErrorMessageViewModel = new MessageViewModel();
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);
            CreatePlaylistCommand = new CreatePlaylistCommand(this, _authenticator, _playlistRepository);
            RemovePlaylistCommand = new RemovePlaylistCommand(this, playlistRepository);
            Playlists = new ObservableCollection<Playlist>();
            NewPlaylistName = "";
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
