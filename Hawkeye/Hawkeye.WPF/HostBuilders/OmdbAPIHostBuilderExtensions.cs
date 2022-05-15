using Hawkeye.OmdbAPI;
using Hawkeye.OmdbAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Hawkeye.WPF.HostBuilders
{
    public static class OmdbAPIHostBuilderExtensions
    {
        public static IHostBuilder AddMovieAPI(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string apiKey = "6f51d678-ae9a-401e-9ed3-6746bda409e6";// context.Configuration.GetValue<string>("MOVIE_API_KEY");
                services.AddSingleton(new OmdbApiKey(apiKey));

                services.AddHttpClient<OmdbHttpClient>(c =>
                {
                    c.BaseAddress = new Uri("https://kinopoiskapiunofficial.tech/");
                });
            });
            return host;
        }
    }
}
