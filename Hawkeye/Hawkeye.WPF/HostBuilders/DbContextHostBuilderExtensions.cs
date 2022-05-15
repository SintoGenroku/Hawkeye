using Hawkeye.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.WPF.HostBuilders
{
    public static class DbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                void configureDbContext(DbContextOptionsBuilder o) => o.UseSqlServer(connectionString);

                services.AddDbContext<HawkeyeDbContext>(configureDbContext);
                services.AddScoped<HawkeyeDbContext>();
                services.AddSingleton<HawkeyeDbContextFactory>(new HawkeyeDbContextFactory((Action<DbContextOptionsBuilder>)configureDbContext));
            });

            return host;
        }
    }
}
