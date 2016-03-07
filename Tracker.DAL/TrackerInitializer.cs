using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tracker.DAL.Entities;

namespace Tracker.DAL
{
    public class TrackerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TrackerContext>
    {
        protected override void Seed(TrackerContext context)
        {
            context.Authors.Add(new AuthorEntity()
            {
                FirstName = "Dan",
                LastName = "Brown",

                BookEntities = new List<BookEntity>()
                {
                    new BookEntity{Name="Inferno", DateRead=DateTime.Parse("2013-12-01"), Rating=8},
                    new BookEntity{Name="DaVinci Code", DateRead=DateTime.Parse("2010-03-10"), Rating=7}
                }
            });
            context.SaveChanges();

            context.Authors.Add(new AuthorEntity()
            {
                FirstName = "J.K.",
                LastName = "Rowling",

                BookEntities = new List<BookEntity>()
                {
                    new BookEntity{Name="Harry Potter and the Philosopher's Stone", DateRead=DateTime.Parse("2003-12-07"), Rating=9},
                    new BookEntity{Name="Harry Potter and the Chamber of Secrets", DateRead=DateTime.Parse("2005-09-26"), Rating=8},
                    new BookEntity{Name="Harry Potter and the Prisoner of Azkaban", DateRead=DateTime.Parse("2008-02-23"), Rating=7}
                }
            });
            context.SaveChanges();
        }
    }
}
