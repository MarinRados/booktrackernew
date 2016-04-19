using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tracker.DAL.Entities;

namespace Tracker.DAL
{
    public class TrackerContext : DbContext, ITrackerContext
    {
        public TrackerContext()
            : base("TrackerContext")
        {
        }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Books { get; set; }
    }
}
