using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Repository.Common
{
    public interface IGenericRepository
    {
        IUnitOfWork CreateUnitOfWork();

        Task<T> GetAsync<T>(Guid id) where T : class;
        IQueryable<T> Where<T>() where T : class;

        Task<T> GetAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<IEnumerable<T>> GetEverything<T>() where T : class;

        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;
    }
}
