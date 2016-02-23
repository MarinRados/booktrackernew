using System;
using System.Collections.Generic;

namespace Tracker.DAL.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public ICollection<BookEntity> Books { get; set; }
    }
}
