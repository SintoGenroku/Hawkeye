using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework;
using Hawkeye.EntityFramework.Repositories;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.Foundation.Services;
using Hawkeye.Foundation.Services.Abstracts;
using Hawkeye.WPF.State.Navigators;
using Hawkeye.WPF.ViewModels;
using Hawkeye.WPF.ViewModels.Factories;
using Hawkeye.WPF.ViewModels.Factories.Abstracts;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Hawkeye.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            
            /*var q = new FilmService().GetFilmData(435).Result;
            MessageBox.Show($"{q.NameRu}");*/

            IServiceProvider serviceProvider = CreateServiceProvider();
            IAccountService accountService = serviceProvider.GetService<IAccountService>();
            //HawkeyeDbContextFactory dbContextFactory = serviceProvider.GetService<HawkeyeDbContextFactory>();
            IUserRepository userRepository = serviceProvider.GetService<IUserRepository>();
            IRoleRepository roleRepository = serviceProvider.GetService<IRoleRepository>();

/*            userRepository.CreateAsync(new User()
            {
                Name = "sinto",
                PasswordHash = "qwerty123",
                Role = roleRepository.GetByNameAsync("USER").Result
            });*/
            accountService.RegisterAsync("unek", "qwerty", "qwerty");

            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            //services.AddSingleton<HawkeyeDbContextFactory>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<FilmsViewModel>, FilmsViewModelFactory>();
            services.AddSingleton<IViewModelFactory<FavoriteViewModel>, FavoriteViewModelFactory>();
            services.AddSingleton<IViewModelFactory<PlaylistsViewModel>, PlaylistsViewModelFactory>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddDbContext<HawkeyeDbContext>(options => options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HawkeyeDB;Trusted_Connection=True;"));

            services.AddScoped<INavigator, Navigator>();

            services.AddScoped<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
