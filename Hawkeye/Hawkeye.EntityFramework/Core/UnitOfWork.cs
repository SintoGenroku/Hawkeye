using Hawkeye.EntityFramework.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.EntityFramework.Core
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _instances;
        private readonly Dictionary<Type, Type> _specificRepositories;
        private readonly HawkeyeDbContext _dbContext;

        protected UnitOfWork(HawkeyeDbContext dbContext)
        {
            _dbContext = dbContext;
            _instances = new Dictionary<Type, object>();
            _specificRepositories = new Dictionary<Type, Type>();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (!_instances.ContainsKey(typeof(T)))
            {
                if (!_specificRepositories.TryGetValue(typeof(T), out var repositoryType))
                {
                    repositoryType = typeof(Repository<T>);
                }

                _instances.Add(typeof(T), Activator.CreateInstance(repositoryType, _dbContext));
            }

            return (IRepository<T>)_instances[typeof(T)];
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        protected void AddSpecificRepository<TEntity, TRepositoryType>() where TRepositoryType : IRepository<TEntity>
        {
            _specificRepositories.Add(typeof(TEntity), typeof(TRepositoryType));
        }
    }
}
