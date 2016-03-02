using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using PagedList;
using Tracker.Repository.Common;
using Tracker.DAL;
using Tracker.DAL.Entities;
using Tracker.Common.Filters;
using Tracker.Model;
using Tracker.Model.Common;

namespace Tracker.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IGenericRepository Repository;

        public BookRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<IBook> GetAsync(Guid id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IBook>(await Repository.GetAsync<BookEntity>(id));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<IBook>> GetAllAsync(Guid authorId, GenericFilter filter)
        {
            try
            {
                if(filter != null)
                {
                    var bk = AutoMapper.Mapper.Map<IEnumerable<IBook>>(await Repository.GetEverything<BookEntity>()).OrderBy(b => b.Name).ToList();

                    if(authorId != null)
                    {
                        bk = bk.Where(b => b.AuthorId.Equals(authorId)).ToList();
                    }

                    var page = bk.ToPagedList(filter.pageNumber, filter.pageSize);
                    var bkPage = new StaticPagedList<IBook>(page, page.GetMetaData());
                    return bkPage;
                }
                else
                {
                    return AutoMapper.Mapper.Map<IEnumerable<IBook>>(await Repository.GetAllAsync<BookEntity>(b => b.AuthorId.Equals(authorId))).OrderBy(b => b.DateRead).ToList();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<IBook>> GetEverythingAsync(GenericFilter filter)
        {
            try
            {
                if(filter != null)
                {
                    var bk = AutoMapper.Mapper.Map<IEnumerable<IBook>>(await Repository.GetEverything<BookEntity>()).OrderBy(b => b.Name).ToList();

                    if(!string.IsNullOrWhiteSpace(filter.searchString))
                    {
                        bk = bk.Where(b =>
                            b.Name.ToLower().Contains(filter.searchString.ToLower()) ||
                            b.Author.FullName.ToLower().Contains(filter.searchString.ToLower())
                            ).ToList();
                    }
                    var page = bk.ToPagedList(filter.pageNumber, filter.pageSize);
                    var bkPage = new StaticPagedList<IBook>(page, page.GetMetaData());
                    return bkPage;
                }
                else
                {
                    return AutoMapper.Mapper.Map<IEnumerable<IBook>>(await Repository.GetEverything<BookEntity>()).OrderBy(b => b.Name).ToList();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> AddAsync(IBook bk)
        {
            try
            {
                bk.Id = Guid.NewGuid();
                return await Repository.AddAsync<BookEntity>(AutoMapper.Mapper.Map<BookEntity>(bk));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(IBook bk)
        {
            try
            {
                return await Repository.UpdateAsync<AuthorEntity>(AutoMapper.Mapper.Map<AuthorEntity>(bk));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(IBook bk)
        {
            try
            {
                return await Repository.DeleteAsync<BookEntity>(AutoMapper.Mapper.Map<BookEntity>(bk));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(params Guid[] id)
        {
            try
            {
                IUnitOfWork uow = Repository.CreateUnitOfWork();
                foreach (Guid i in id)
                {
                    await uow.DeleteAsync<BookEntity>(i);
                }
                return await uow.CommitAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
