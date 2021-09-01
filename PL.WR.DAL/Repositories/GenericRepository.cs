using Microsoft.EntityFrameworkCore;
using PL.WR.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL.WR.DAL.Repositories
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        internal DbContext ctx;
        internal DbSet<TEntity> dbset;

        public GenericRepository(DbContext context)
        {
            this.ctx = context;
            this.dbset = ctx.Set<TEntity>();
        }

        public void Delete(object Id)
        {
            TEntity entity = dbset.Find(Id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            if (ctx.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);
            }

            dbset.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entityList)
        {
            dbset.RemoveRange(entityList);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includeProperties = "")
        {

            IQueryable<TEntity> entities = dbset;

            if (filter != null)
            {
                entities = entities.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
            {
                entities = entities.Include(includeProperty);
            }

            if (orderby != null)
            {
                return orderby(entities).ToList();
            }
            else
            {
                return entities.ToList();
            }

        }

        public IEnumerable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>().ToList();
        }

        public void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }

        public void InsertRange(List<TEntity> entityList)
        {
            dbset.AddRange(entityList);
        }

        public void Update(TEntity entity)
        {
            dbset.Attach(entity);
            ctx.Entry(entity).State = EntityState.Modified;
        }

    }
}
