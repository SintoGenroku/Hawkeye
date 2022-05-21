using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Hawkeye.WPF.ViewModels;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using Hawkeye.WPF.ViewModels.Factories;
using Hawkeye.EntityFramework.Repositories.Abstracts;

namespace Hawkeye.WPF.HostBuilders
{
    public static class ViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
           {
               services.AddTransient<PlaylistsViewModel>();
               services.AddTransient<FavoriteViewModel>();
               services.AddTransient<FilmsViewModel>();
               services.AddTransient<MainViewModel>();
               services.AddTransient<HomeViewModel>();
               services.AddTransient<CurrentFilmViewModel>();
               services.AddTransient<CurrentPlaylistViewModel>();
               services.AddTransient<ProfileViewModel>();
               services.AddTransient<AdminPanelViewModel>();

               services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => CreateHomeViewModel(services));
               services.AddSingleton <CreateViewModel<FilmsViewModel>>(services => () => CreateFilmsViewModel(services));
               services.AddSingleton<CreateViewModel<PlaylistsViewModel>>(services => () => services.GetRequiredService<PlaylistsViewModel>());
               services.AddSingleton<CreateViewModel<FavoriteViewModel>>(services => () => CreateFavoriteViewModel(services));
               services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
               services.AddSingleton<CreateViewModel<RegistrationViewModel>>(services => () => CreateRegisterViewModel(services));
               services.AddSingleton<CreateViewModel<CurrentFilmViewModel>>(services => () => services.GetRequiredService<CurrentFilmViewModel>());
               services.AddSingleton<CreateViewModel<CurrentPlaylistViewModel>>(services => () => CreateCurrentPlaylistViewModel(services));
               services.AddSingleton<CreateViewModel<ProfileViewModel>>(services => () => CreateProfileViewModel(services));
               services.AddSingleton<CreateViewModel<AdminPanelViewModel>>(services => () => CreateAdminPanelViewModel(services));

               services.AddSingleton<IViewModelFactory, ViewModelFactory>();

               services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
               services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
               services.AddSingleton<ViewModelDelegateRenavigator<RegistrationViewModel>>();
               


           });
            return host;
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<IFilmRepository>(),
                services.GetRequiredService<INavigator>(),
                services.GetRequiredService<IViewModelFactory>()
               );
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegistrationViewModel>>());
        }

        private static RegistrationViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegistrationViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }
        private static FilmsViewModel CreateFilmsViewModel(IServiceProvider services)
        {
            return new FilmsViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<IFilmRepository>(),
                services.GetRequiredService<IUserRepository>(),
                services.GetRequiredService<INavigator>(),
                services.GetRequiredService<IViewModelFactory>());
        }

        private static FavoriteViewModel CreateFavoriteViewModel(IServiceProvider services)
        {
            return new FavoriteViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<IFilmRepository>(),
                services.GetRequiredService<IUserRepository>(),
                services.GetRequiredService<INavigator>(),
                services.GetRequiredService<IViewModelFactory>());
        }

        private static CurrentPlaylistViewModel CreateCurrentPlaylistViewModel(IServiceProvider services)
        {
            return new CurrentPlaylistViewModel(
                services.GetRequiredService<IPlaylistRepository>(),
                services.GetRequiredService<IFilmRepository>(),
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<INavigator>(),
                services.GetRequiredService<IViewModelFactory>()
                );
        }
        private static ProfileViewModel CreateProfileViewModel(IServiceProvider services)
        {
            return new ProfileViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<INavigator>(),
                services.GetRequiredService<IViewModelFactory>()
                );
        }

        private static AdminPanelViewModel CreateAdminPanelViewModel(IServiceProvider services)
        {
            return new AdminPanelViewModel(services.GetRequiredService<ICommentRepository>());
        }
    }
}
