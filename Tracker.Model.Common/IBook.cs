using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Model.Common
{
    public interface IBook
    {
        int Id { get; set; }
        int AuthorId { get; set; }
        string Name { get; set; }
        DateTime? DateRead { get; set; }
        int? Rating { get; set; }

        IAuthor Author { get; set; }
    }
}
