using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Model.Common;
using Tracker.DAL;
using Tracker.Common;
using Tracker.Common.Filters;

namespace Tracker.Service.Common
{
    public interface IBookService
    {
        Task<IBook> FindByIdAsync(Guid id);
        Task<IEnumerable<IBook>> GetAllBooks(GenericFilter filter);
        Task<IEnumerable<IBook>> GetFromAuthor(Guid id, GenericFilter filters);

        Task<int> AddBook(IBook bk);
        Task<int> UpdateBook(IBook bk);
        Task<int> DeleteBook(Guid id);
    }
}
