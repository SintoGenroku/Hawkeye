using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hawkeye.EntityFramework
{
    public class HawkeyeDbContextFactory : IDesignTimeDbContextFactory<HawkeyeDbContext>
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public HawkeyeDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public HawkeyeDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<HawkeyeDbContext>();
            options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HawkeyeDB;Trusted_Connection=True;");
            _configureDbContext(options);
            return new HawkeyeDbContext(options.Options);
        }
    }
}
