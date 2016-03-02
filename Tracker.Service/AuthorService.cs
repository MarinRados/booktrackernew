using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.DAL;
using Tracker.Model.Common;
using Tracker.Repository.Common;
using Tracker.Service.Common;
using Tracker.Common.Filters;

namespace Tracker.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository Repository;

        public AuthorService(IAuthorRepository repository)
        {
            Repository = repository;
            if (Repository == null)
            {
                throw new ArgumentNullException("Repository is null");
            }
        }

        public Task<IAuthor> GetByIdAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        public Task<IEnumerable<IAuthor>> GetAllAsync(GenericFilter filter)
        {
            return Repository.GetAsync(filter);
        }

        public Task<int> AddAsync(IAuthor at)
        {
            return Repository.UpdateAsync(at);
        }

        public Task<int> UpdateAsync(IAuthor at)
        {
            return Repository.UpdateAsync(at);
        }

        public Task<int> DeleteAsync(Guid id)
        {
            return Repository.DeleteAsync(id);
        }
    }
}
