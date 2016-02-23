using System;
using System.Collections.Generic;

namespace Tracker.DAL.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }

        public AuthorEntity Author { get; set; }
    }
}
