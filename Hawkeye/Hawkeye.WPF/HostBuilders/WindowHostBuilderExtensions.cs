using Hawkeye.WPF.ViewModels;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace Hawkeye.WPF.HostBuilders
{
    public static class WindowHostBuilderExtensions
    {
        public static IHostBuilder AddWindow(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });

            return host;
        }
    }
}
