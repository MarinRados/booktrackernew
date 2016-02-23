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
            var authors = new List<AuthorEntity>
            {
                new AuthorEntity{FirstName="J.K.", LastName="Rowling"},
                new AuthorEntity{FirstName="Dan", LastName="Brown"},
                new AuthorEntity{FirstName="J.R.R.", LastName="Tolkien"},
                new AuthorEntity{FirstName="Ian", LastName="Fleming"},
                new AuthorEntity{FirstName="William", LastName="Shakespeare"}
            };
            authors.ForEach(s => context.Authors.Add(s));
            context.SaveChanges();

            var books = new List<BookEntity>
            {
                new BookEntity{Name="Harry Potter and the Philosopher's Stone", DateRead=DateTime.Parse("2010-09-04"), Rating=8, AuthorId=1},
                new BookEntity{Name="Harry Potter and the Chamber of Secrets",  DateRead=DateTime.Parse("2010-11-12"), Rating=9,AuthorId=1},
                new BookEntity{Name="The Da Vinci Code", DateRead=DateTime.Parse("2008-05-01"), Rating=7, AuthorId=2},
                new BookEntity{Name="Inferno", DateRead=null, Rating=null, AuthorId=2 },
                new BookEntity{Name="The Hobbit", DateRead=DateTime.Parse("2006-06-22"), Rating=10, AuthorId=3},
                new BookEntity{Name="Dr.No", DateRead=DateTime.Parse("2010-03-24"), Rating=6, AuthorId=4},
                new BookEntity{Name="Casino Royale", DateRead=null, Rating=null, AuthorId=4 },
                new BookEntity{Name="Hamlet", DateRead=DateTime.Parse("2007-10-13"), Rating=8, AuthorId=5 }
            };
            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();
        }
    }
}