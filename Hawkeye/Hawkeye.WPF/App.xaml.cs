using Hawkeye.EntityFramework;
using Hawkeye.OmdbAPI;
using Hawkeye.OmdbAPI.Services;
using Hawkeye.WPF.HostBuilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace Hawkeye.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {

            return Host.CreateDefaultBuilder(args)
                        .AddConfig()
                        .AddDbContext()
                        .AddServices()
                        //.AddMovieAPI()
                        .AddViewModels()
                        .AddWindow();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            HawkeyeDbContextFactory contextFactory = _host.Services.GetRequiredService<HawkeyeDbContextFactory>();
            using (HawkeyeDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }
            #region MyRegion
            /*var q = new FilmService().GetFilmData(435).Result;
    MessageBox.Show($"{q.NameRu}");*/

            /*            userRepository.CreateAsync(new User()
                        {
                            Name = "sinto",
                            PasswordHash = "qwerty123",
                            Role = roleRepository.GetByNameAsync("USER").Result
                        });*/
            //accountService.RegisterAsync("unek", "qwerty", "qwerty");

            #endregion
            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
            /*  var omdb = _host.Services.GetRequiredService<IFilmService>();
              var film = omdb.GetFilmData(435).Result;
              MessageBox.Show($"{film}");*/

        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);


        }
    }
}
