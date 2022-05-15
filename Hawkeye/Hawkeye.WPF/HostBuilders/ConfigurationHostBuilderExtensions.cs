using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.WPF.HostBuilders
{
    public static class ConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddConfig(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile(@"appsettings.json");
                    c.AddEnvironmentVariables();
                });

                return host;

        }
    }
}
