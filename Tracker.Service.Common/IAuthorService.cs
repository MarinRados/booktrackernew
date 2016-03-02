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
    public interface IAuthorService
    {
        Task<IAuthor> GetByIdAsync(Guid id);
        Task<IEnumerable<IAuthor>> GetAllAsync(GenericFilter filter);
        Task<int> AddAsync(IAuthor at);
        Task<int> UpdateAsync(IAuthor at);
        Task<int> DeleteAsync(Guid id);
    }
}
