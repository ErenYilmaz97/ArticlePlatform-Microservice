using Microservices.Core.Entity;
using Microservices.Core.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Repository
{
    public class EfRepository<TContext, TEntity, TPrimarKey> : IRepository<TEntity, TPrimarKey>  where TContext : DbContext   where TEntity : Entity<TPrimarKey>
    {

        private readonly TContext _context;
        private readonly IQueryable<TEntity> _entities;

        public EfRepository(TContext context)
        {
            this._context = context;
            this._entities = _context.Set<TEntity>();
        }

      

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, 
                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, 
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, 
                                    bool disableTracking = true)

        {
            IQueryable<TEntity> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.AsQueryable().ToList();
        }




        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, 
                                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, 
                                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, 
                                               bool disableTracking = true)

        {
            IQueryable<TEntity> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.AsQueryable().ToListAsync();
        }




        public TEntity Get(Expression<Func<TEntity, bool>> filter = null,
                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                           bool disableTracking = true)

        {
            IQueryable<TEntity> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            return query.AsQueryable().FirstOrDefault(filter);
        }




        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, 
                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, 
                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, 
                                      bool disableTracking = true)

        {
            IQueryable<TEntity> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            return await query.AsQueryable().FirstOrDefaultAsync(filter);
        }




        public PagedList<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter = null, 
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, 
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, 
                                           bool disableTracking = true, PagingParams pagingParams = null)

        {
            IQueryable<TEntity> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }


            int skip = 0;
            int take = 20;
            int totalCount = 0;

            if (pagingParams != null)
            {
                int pageNumber = pagingParams.PageNumber == 0 ? 1 : pagingParams.PageNumber;
                int pageSize = pagingParams.PageSize == 0 ? 20 : pagingParams.PageSize;

                skip = (pageNumber - 1) * pageSize;
                take = pageSize;
            }

            totalCount = query.Count();

            return new PagedList<TEntity>()
            {
                TotalCount = totalCount,
                Result = query.Skip(skip).Take(take).ToList(),
                HasNext = (skip + take) < totalCount,
                HasPrevious = skip != 0
            };
        }




        public async Task<PagedList<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> filter = null, 
                                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, 
                                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, 
                                                      bool disableTracking = true, PagingParams pagingParams = null)
        {
            IQueryable<TEntity> query = _entities;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderby != null)
            {
                query = orderby(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }


            int skip = 0;
            int take = 20;
            int totalCount = 0;

            if (pagingParams != null)
            {
                int pageNumber = pagingParams.PageNumber == 0 ? 1 : pagingParams.PageNumber;
                int pageSize = pagingParams.PageSize == 0 ? 20 : pagingParams.PageSize;

                skip = (pageNumber - 1) * pageSize;
                take = pageSize;
            }

            totalCount = await query.CountAsync();

            return new PagedList<TEntity>()
            {
                TotalCount = totalCount,
                Result = await query.Skip(skip).Take(take).ToListAsync(),
                HasNext = (skip + take) < totalCount,
                HasPrevious = skip != 0
            };
        }




        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }


        public async Task InsertAsync(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
        }


        public void Remove(TPrimarKey entityId)
        {
            TEntity entity = this.Get(filter: x => x.Id.Equals(entityId), disableTracking : false);
            this.Remove(entity);
        }


        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }


        public async Task RemoveAsync(TPrimarKey entityId)
        {
            TEntity entity = await this.GetAsync(filter: x => x.Id.Equals(entityId), disableTracking: false);
            this.Remove(entity);
        }


        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
