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
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRespository)
        {
            this.bookRepository = bookRepository;
            if (bookRepository == null)
            {
                throw new ArgumentNullException("bookRepository is null");
            }
        }

        public Task<IBook> FindByIdAsync(Guid id)
        {
            return bookRepository.GetAsync(id);
        }

        public virtual Task<IEnumerable<IBook>> GetAllBooks(GenericFilter filter)
        {
            try
            {
                return bookRepository.GetEverythingAsync(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<IBook>> GetFromAuthor(Guid id, GenericFilter filter)
        {
            return bookRepository.GetAllAsync(id);
        }

        public Task<int> AddBook(IBook bk)
        {
            try
            {
                return bookRepository.AddAsync(bk);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Task<int> UpdateBook(IBook bk)
        {
            return bookRepository.UpdateAsync(bk);
        }

        public Task<int> DeleteBook(Guid id)
        {
            return bookRepository.DeleteAsync(id);
        }
    }
}
