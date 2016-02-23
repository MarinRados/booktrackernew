using System;
using System.Collections.Generic;
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

        public UnitOfWork(ITrackerContext context)
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
    }
}
