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
    public class AuthorRepository 
    {
        private readonly IGenericRepository Repository;

        public AuthorRepository(IGenericRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<IAuthor> GetAsync(Guid id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IAuthor>(await Repository.GetAsync<AuthorEntity>(id));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<IAuthor>> GetAsync(GenericFilter filter)
        {
            try
            {
                if (filter != null)
                {
                    var at = AutoMapper.Mapper.Map<IEnumerable<IAuthor>>(await Repository.GetEverything<AuthorEntity>()).OrderBy(a => a.LastName).ToList();

                    if(!string.IsNullOrWhiteSpace(filter.searchString))
                    {
                        at = at.Where(a => a.LastName.ToLower().Contains(filter.searchString.ToLower()) ||
                            a.FirstName.ToLower().Contains(filter.searchString.ToLower())).ToList();
                    }

                    var page = at.ToPagedList(filter.pageNumber, filter.pageSize);
                    var atPage = new StaticPagedList<IAuthor>(page, page.GetMetaData());
                    return atPage;
                }
                else
                {
                    return AutoMapper.Mapper.Map<IEnumerable<IAuthor>>(await Repository.GetEverything<AuthorEntity>()).OrderBy(a => a.LastName).ToList();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> AddAsync(IAuthor at)
        {
            try
            {
                return await Repository.AddAsync<AuthorEntity>(AutoMapper.Mapper.Map<AuthorEntity>(at));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(IAuthor at)
        {
            try
            {
                return await Repository.UpdateAsync<AuthorEntity>(AutoMapper.Mapper.Map<AuthorEntity>(at));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(IAuthor at)
        {
            try
            {
                return await Repository.DeleteAsync<AuthorEntity>(AutoMapper.Mapper.Map<AuthorEntity>(at));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await Repository.DeleteAsync<AuthorEntity>(id);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
