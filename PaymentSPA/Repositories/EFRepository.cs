using PaymentSPA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PaymentSPA.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }

        public EFRepository(DbContext context)
        {
            if (context == null) throw new ArgumentException("context");
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }


        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }


        public IList<TEntity> GetAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereExpression = null)
        {
            return DbSet.Where(whereExpression).ToList();
        }


        public void DeleteById(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }


        public void Delete(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }
    }
}