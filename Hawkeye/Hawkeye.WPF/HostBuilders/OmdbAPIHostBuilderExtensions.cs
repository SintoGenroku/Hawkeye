using Hawkeye.OmdbAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Hawkeye.WPF.HostBuilders
{
    public static class OmdbAPIHostBuilderExtensions
    {
/*        public static IHostBuilder AddMovieAPI(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string apiKey = context.Configuration.GetValue<string>("MOVIE_API_KEY");
                services.AddSingleton(new OmdbApiKey(apiKey));

                services.AddHttpClient<OmdbApiKey>(c =>
                {
                    c.BaseAddress = new Uri("https://kinopoiskapiunofficial.tech/");
                });
            });
        }*/
    }
}
