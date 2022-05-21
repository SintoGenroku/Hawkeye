using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.Foundation.Services;
using Hawkeye.WPF.Commands;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hawkeye.WPF.ViewModels
{
    public class FilmsViewModel : ViewModelBase
    {

        private readonly IViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private IFilmRepository FilmRepository;
        private IUserRepository _userRepository;
        public ICommand UpdateCurrentViewModelCommand {get;}
        public ICommand AddFilmToFavoriteCommand { get; }
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ObservableCollection<Film> Films { get; set; }
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


        public FilmsViewModel(IAuthenticator authenticator, 
                              IFilmRepository filmRepository, 
                              IUserRepository userRepository, 
                              INavigator navigator, 
                              IViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            FilmRepository = filmRepository;
            _userRepository = userRepository;
            _viewModelFactory = viewModelFactory;
         
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);
            AddFilmToFavoriteCommand = new AddFilmToFavoriteCommand(authenticator, filmRepository, _userRepository);

            Films = new ObservableCollection<Film>();
            var items = FilmRepository.GetAllAsync().Result;
            foreach(var item in items)
            {
                Films.Add(item);
            }
            
        }
    }
}
