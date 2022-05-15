using Hawkeye.Domain.Models;
using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.WPF.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<FilmsViewModel> _createFilmsViewModel;
        private readonly CreateViewModel<PlaylistsViewModel> _createPlaylistsViewModel;
        private readonly CreateViewModel<FavoriteViewModel> _createFavoriteViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<CurrentFilmViewModel> _createCurrentFilmViewModel;


        public ViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel, 
                                CreateViewModel<FilmsViewModel> createFilmsViewModel, 
                                CreateViewModel<PlaylistsViewModel> createPlaylistsViewModel, 
                                CreateViewModel<FavoriteViewModel> createFavoriteViewModel,
                                CreateViewModel<LoginViewModel> createLoginViewModel,
                                CreateViewModel<CurrentFilmViewModel> createCurrentFilmViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createFilmsViewModel = createFilmsViewModel;
            _createPlaylistsViewModel = createPlaylistsViewModel;
            _createFavoriteViewModel = createFavoriteViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createCurrentFilmViewModel = createCurrentFilmViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Films:
                    return _createFilmsViewModel();
                case ViewType.Playlists:
                    return _createPlaylistsViewModel();
                case ViewType.Profile:
                    return new ProfileViewModel();
                case ViewType.Favorite:
                    return _createFavoriteViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.CurrentFilm:
                        return _createCurrentFilmViewModel();
                default:
                    throw new ArgumentException("The ViewType doesn't have a ViewModel", "viewType");
            }
        }
    }
}
