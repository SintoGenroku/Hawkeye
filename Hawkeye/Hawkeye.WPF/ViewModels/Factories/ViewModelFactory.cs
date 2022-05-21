using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System;

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
        private readonly CreateViewModel<CurrentPlaylistViewModel> _createCurrentPlaylistViewModel;
        private readonly CreateViewModel<ProfileViewModel> _createProfileViewModel;
        private readonly CreateViewModel<AdminPanelViewModel> _createAdminPanelViewModel;


        public ViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
                                CreateViewModel<FilmsViewModel> createFilmsViewModel,
                                CreateViewModel<PlaylistsViewModel> createPlaylistsViewModel,
                                CreateViewModel<FavoriteViewModel> createFavoriteViewModel,
                                CreateViewModel<LoginViewModel> createLoginViewModel,
                                CreateViewModel<CurrentFilmViewModel> createCurrentFilmViewModel,
                                CreateViewModel<CurrentPlaylistViewModel> createCurrentPlaylistViewModel,
                                CreateViewModel<ProfileViewModel> createProfileViewModel, 
                                CreateViewModel<AdminPanelViewModel> createAdminPanelViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createFilmsViewModel = createFilmsViewModel;
            _createPlaylistsViewModel = createPlaylistsViewModel;
            _createFavoriteViewModel = createFavoriteViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createCurrentFilmViewModel = createCurrentFilmViewModel;
            _createCurrentPlaylistViewModel = createCurrentPlaylistViewModel;
            _createProfileViewModel = createProfileViewModel;
            _createAdminPanelViewModel = createAdminPanelViewModel;
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
                    return _createProfileViewModel();
                case ViewType.Favorite:
                    return _createFavoriteViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.CurrentFilm:
                    return _createCurrentFilmViewModel();
                case ViewType.CurrentPlaylist:
                    return _createCurrentPlaylistViewModel();
                case ViewType.AdminPanel:
                    return _createAdminPanelViewModel();
                default:
                    throw new ArgumentException("The ViewType doesn't have a ViewModel", "viewType");
            }
        }
    }
}
