using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using System;

namespace Hawkeye.WPF.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IViewModelFactory<FilmsViewModel> _filmsViewModelFactory;
        private readonly IViewModelFactory<PlaylistsViewModel> _playlistsViewModelFactory;
        private readonly IViewModelFactory<FavoriteViewModel> _favoriteViewModelFactory;

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Films:
                    return _filmsViewModelFactory.CreateViewModel();
                case ViewType.Playlists:
                    return _playlistsViewModelFactory.CreateViewModel();
                case ViewType.Actors:
                    return new ActorsViewModel();
                case ViewType.Profile:
                    return new ProfileViewModel();
                case ViewType.Favorite:
                    return _favoriteViewModelFactory.CreateViewModel();
                case ViewType.Login:
                    return new LoginViewModel();
                case ViewType.Registration:
                    return new RegistrationViewModel();
                default:
                    throw new ArgumentException("The ViewType doesn't have a ViewModel", "viewType");
            }
        }
    }
}
