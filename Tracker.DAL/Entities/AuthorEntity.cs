using System;
using System.Collections.Generic;

namespace Tracker.DAL.Entities
{
    public class AuthorEntity
    {
        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public virtual ICollection<BookEntity> Books { get; set; }
    }
}
