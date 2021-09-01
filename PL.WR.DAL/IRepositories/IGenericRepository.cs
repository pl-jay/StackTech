using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL.WR.DAL.IRepositories
{
    public interface IGenericRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includeProperties = "");

        void Insert(TEntity entity);

        void InsertRange(List<TEntity> entityList);

        void Delete(object Id);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entityList);

        void Update(TEntity entity);

    }
}
