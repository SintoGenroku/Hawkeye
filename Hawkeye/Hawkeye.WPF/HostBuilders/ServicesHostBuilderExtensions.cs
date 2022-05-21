using Hawkeye.Domain.Models;
using Hawkeye.EntityFramework.Contracts;
using Hawkeye.EntityFramework.Core;
using Hawkeye.EntityFramework.Repositories;
using Hawkeye.EntityFramework.Repositories.Abstracts;
using Hawkeye.Foundation.Services;
using Hawkeye.Foundation.Services.Abstracts;
using Hawkeye.OmdbAPI;
using Hawkeye.OmdbAPI.Services;
using Hawkeye.WPF.State.Authenticators;
using Hawkeye.WPF.State.Authenticators.Abstracts;
using Hawkeye.WPF.State.Navigators;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hawkeye.WPF.HostBuilders
{
    public static class ServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services => 
            {
                services.AddSingleton<IAccountService, AccountService>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddTransient<IRepository<Comment>, Repository<Comment>>();
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IPlaylistRepository, PlaylistRepository>();
                services.AddScoped<IFilmRepository, FilmRepository>();
                services.AddScoped<ICommentRepository, CommentRepository>();
                services.AddScoped<IRoleRepository, RoleRepository>();
                services.AddSingleton<IPasswordHasher, PasswordHasher>();
                services.AddSingleton<INavigator, Navigator>();
                services.AddScoped<OmdbHttpClient>();
                services.AddScoped<IFilmService, FilmService>();


            });
            return host;
        }
    }
}
