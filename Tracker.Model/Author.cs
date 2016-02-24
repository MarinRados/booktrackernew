using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Model.Common;

namespace Tracker.Model
{
    public class Author : IAuthor
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

        public virtual ICollection<IBook> Books { get; set; }
    }
}
