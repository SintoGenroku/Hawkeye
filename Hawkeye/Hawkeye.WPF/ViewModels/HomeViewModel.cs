using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.Foundation.Services;
using Hawkeye.WPF.Commands;
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
    public class HomeViewModel : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IFilmRepository _filmRepository;
        public User LoggedUser => _authenticator.CurrentUser;
        public bool isAdmin => LoggedUser.Role.Name == "ADMIN";
        public ObservableCollection<Film> RandomFilmsForUser { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

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

        public HomeViewModel(IAuthenticator authenticator, IFilmRepository filmRepository, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _filmRepository = filmRepository;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);
            

            RandomFilmsForUser = new ObservableCollection<Film>();
            var randomFilms = _filmRepository.GetAllAsync().Result.OrderBy(rf => Guid.NewGuid()).Take(3);
            foreach(var film in randomFilms)
            {
                RandomFilmsForUser.Add(film);
            } 
        }
    }
}
