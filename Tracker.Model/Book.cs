using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Model.Common;

namespace Tracker.Model
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }

        public IAuthor Author { get; set; }
    }
}
