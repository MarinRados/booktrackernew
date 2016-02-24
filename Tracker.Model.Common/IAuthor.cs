using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Model.Common
{
    public interface IAuthor
    {
        Guid AuthorId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }

        ICollection<IBook> Books { get; set; }
    }
}
