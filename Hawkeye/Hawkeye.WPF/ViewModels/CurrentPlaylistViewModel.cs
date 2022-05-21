using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.Foundation.Services;
using Hawkeye.WPF.Commands;
using Hawkeye.WPF.Models;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hawkeye.WPF.ViewModels
{
    public class CurrentPlaylistViewModel : ViewModelBase
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand AddFilmToPlaylistCommand { get; }
        public ICommand RemoveFilmFromPlaylistCommand { get; }
        public string AddFilmName { get; set; }
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        private Film _selectedFilm;
        public Film SelectedFilm
        {
            get { return _selectedFilm; }
            set
            {
                _selectedFilm = value;
                FilmStorage.Film = value;
                OnPropertyChanged();
                UpdateCurrentViewModelCommand.Execute(ViewType.CurrentFilm);
                OnPropertyChanged(nameof(_navigator.CurrentViewModel));
            }
        }

        public CurrentPlaylistViewModel(IPlaylistRepository playlistRepository, IFilmRepository filmRepository, IAuthenticator authenticator, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            _playlistRepository = playlistRepository;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            ErrorMessageViewModel = new MessageViewModel();
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);
            AddFilmToPlaylistCommand = new AddFilmToPlaylistCommand(this, authenticator, playlistRepository, filmRepository);
            RemoveFilmFromPlaylistCommand = new RemoveFilmFromPlaylistCommand(this, authenticator, playlistRepository, filmRepository);
            AddFilmName = "Название фильма:";
            Playlist = new ObservableCollection<Film>();
            if(PlaylistStorage.Playlist.Films != null)
            {
                foreach (var film in PlaylistStorage.Playlist.Films)
                {
                    Playlist.Add(film);
                }
            }
        }

        public ObservableCollection<Film> Playlist { get; set; }

    }
}
