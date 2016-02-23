using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Tracker.DAL.Entities;

namespace Tracker.DAL
{
    public interface ITrackerContext : IDisposable
    {
        DbSet<AuthorEntity> Authors { get; set; }
        DbSet<BookEntity> Books { get; set; }

        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}
