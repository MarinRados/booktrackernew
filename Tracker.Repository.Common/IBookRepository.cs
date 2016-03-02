using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.DAL;
using Tracker.Model.Common;
using Tracker.Common.Filters;

namespace Tracker.Repository.Common
{
    public interface IBookRepository
    {
        Task<IBook> GetAsync(Guid id);
        Task<IEnumerable<IBook>> GetAllAsync(Guid authorId, GenericFilter filter = null);
        Task<IEnumerable<IBook>> GetEverythingAsync(GenericFilter filter = null);

        Task<int> AddAsync(IBook bk);
        Task<int> UpdateAsync(IBook bk);
        Task<int> DeleteAsync(IBook bk);
        Task<int> DeleteAsync(params Guid[] id);
    }
}
