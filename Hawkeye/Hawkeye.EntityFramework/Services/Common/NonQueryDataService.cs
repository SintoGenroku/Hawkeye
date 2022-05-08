using Hawkeye.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hawkeye.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : DomainObject
    {
        private readonly HawkeyeDbContextFactory _dbContextFactory;

        public NonQueryDataService(HawkeyeDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using(HawkeyeDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await dbContext.Set<T>().AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (HawkeyeDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                T entity = await dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Update(Guid id, T entity)
        {
            using(HawkeyeDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                entity.Id = id;

                dbContext.Set<T>().Update(entity);
                await dbContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}
