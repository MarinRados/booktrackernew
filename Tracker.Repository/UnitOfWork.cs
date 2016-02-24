using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Tracker.DAL;
using Tracker.DAL.Entities;
using Tracker.Repository.Common;


namespace Tracker.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ITrackerContext Context { get; private set; }

        public UnitOfWork(ITrackerContext context, IUnitOfWork uow)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context is null");
            }
            Context = context;
        }

        public Task<T> AddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntity = Context.Entry(entity);
                if (dbEntity.State != EntityState.Detached)
                {
                    dbEntity.State = EntityState.Added;
                }
                else
                {
                    Context.Set<T>().Add(entity);
                }
                return Task.FromResult(dbEntity.Entity as T);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Task<T> Update<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry<T>(entity);
                entry.State = EntityState.Modified;

                return Task.FromResult(entry.Entity as T);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry(entity);
                if(entry.State != EntityState.Deleted)
                {
                    entry.State = EntityState.Deleted;
                }
                return Task.FromResult(1);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            try
            {
                T entity = Context.Set<T>().Find(id);
                if(entity == null)
                {
                    return Task.FromResult(0);
                }
                return DeleteAsync<T>(entity);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Task<int> DeleteAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> match) where T : class
        {
            try
            {
                T entity = Context.Set<T>().Where(match).First();
                if (entity == null)
                {
                    return Task.FromResult(0);
                }
                return DeleteAsync<T>(entity);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
