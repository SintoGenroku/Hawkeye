using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.EntityFramework
{
    public class HawkeyeDbContextFactory : IDesignTimeDbContextFactory<HawkeyeDbContext>
    {
        public HawkeyeDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<HawkeyeDbContext>();
            options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HawkeyeDB;Trusted_Connection=True;");
            return new HawkeyeDbContext(options.Options);
        }
    }
}
