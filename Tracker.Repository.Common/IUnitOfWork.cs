using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<T> AddAsync<T>(T entity) where T : class;
        Task<T> Update<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;
        Task<int> DeleteAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<int> CommitAsync();
    }
}
