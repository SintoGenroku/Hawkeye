using Hawkeye.EntityFramework.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hawkeye.EntityFramework.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HawkeyeDbContext _db;

        protected readonly DbSet<T> Data;
        public Repository(HawkeyeDbContext context)
        {
            _db = context;
            Data = context.Set<T>();
        }

        public async Task CreateAsync(T item)
        {
            Data.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            Data.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<T> FindByIdAsync(params object[] keyValues)
        {
            var result = await Data.FindAsync(keyValues);
            return result;
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            var result =  Data.ToList();
            return result;
        }

        public async Task UpdateAsync(T item)
        {
            _db.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
