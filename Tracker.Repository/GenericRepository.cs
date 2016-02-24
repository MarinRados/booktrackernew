using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using Tracker.DAL;
using System.Data.Entity.Infrastructure;
using Tracker.Repository.Common;

namespace Tracker.Repository
{
    public class GenericRepository : IGenericRepository
    {
        protected ITrackerContext Context { get; private set; }
        protected IUnitOfWorkFactory UoWFac { get; private set; }

        public GenericRepository(ITrackerContext context, IUnitOfWorkFactory uow)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context is null");
            }
            this.Context = context;
            this.UoWFac = uow;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return UoWFac.CreateUnitOfWork();
        }

        public Task<T> GetAsync<T>(Guid id) where T : class
        {
            return Context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> Where<T>() where T : class
        {
            return Context.Set<T>();
        }

        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().FirstAsync(match);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetEverything<T>() where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry(entity);
                if (entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Added;
                }
                else
                {
                    Context.Set<T>().Add(entity);
                }
                return await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
                entry.State = EntityState.Modified;
            }
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                Context.Set<T>().Remove(entity);
                return await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            T entity = await GetAsync<T>(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity is null");
            }
            return await DeleteAsync<T>(entity);
        }
    }
}
