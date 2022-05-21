using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.Foundation.Services;
using Hawkeye.WPF.Commands;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hawkeye.WPF.ViewModels
{
    public class FavoriteViewModel : ViewModelBase
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private IFilmRepository FilmRepository;
        private IUserRepository _userRepository;
        private ObservableCollection<Film> _favorite;

        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand RemoveFromFavoriteCommand { get; }
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public User _currentUser => _authenticator.CurrentUser;

        public ObservableCollection<Film> Favorite 
        {
            get { return _favorite; }
            set 
                {
                    _favorite = value;
                    OnPropertyChanged();
                }
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


        public FavoriteViewModel(IAuthenticator authenticator,
                              IFilmRepository filmRepository,
                              IUserRepository userRepository,
                              INavigator navigator,
                              IViewModelFactory viewModelFactory)
        {
            _authenticator = authenticator;
            _navigator = navigator;
            FilmRepository = filmRepository;
            _userRepository = userRepository;
            _viewModelFactory = viewModelFactory;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);
            RemoveFromFavoriteCommand = new RemoveFromFavoriteCommand(this, authenticator, FilmRepository, _userRepository);

            Favorite = new ObservableCollection<Film>();
            
            foreach (var item in _currentUser.FavoriteFilms)
            { 
                Favorite.Add(item);
            }

        }
    }
}
