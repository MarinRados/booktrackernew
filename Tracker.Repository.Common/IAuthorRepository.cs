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
    public interface IAuthorRepository
    {
        Task<IAuthor> GetAsync(Guid id);
        Task<IEnumerable<IAuthor>> GetAsync(GenericFilter filter = null);

        Task<int> AddAsync(IAuthor at);
        Task<int> UpdateAsync(IAuthor at);
        Task<int> DeleteAsync(Guid id);
    }
}
