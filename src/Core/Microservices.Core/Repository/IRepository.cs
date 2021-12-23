using Microservices.Core.Entity;
using Microservices.Core.Repository.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Repository
{
    //Generic Repository 
    public interface IRepository<TEntity, TPrimaryKey> where TEntity: Entity<TPrimaryKey>
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                            bool disableTracking = true);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                            bool disableTracking = true);




        TEntity Get(Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                    bool disableTracking = true);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                    bool disableTracking = true);





        PagedList<TEntity> GetPaged(Expression<Func<TEntity, bool>> filter = null,
                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                                      bool disableTracking = true,
                                      PagingParams pagingParams = null);

        Task<PagedList<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> filter = null,
                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                                      bool disableTracking = true,
                                      PagingParams pagingParams = null);




        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);


        void Remove(TPrimaryKey entityId);
        Task RemoveAsync(TPrimaryKey entityId);


        void Remove(TEntity entity);


        void Update(TEntity entity);
    }
}
