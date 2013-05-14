using PaymentSPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSPA.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(int id);
        void DeleteById(int id);
        void Delete(TEntity entity);
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> whereExpression = null);

    }
}
