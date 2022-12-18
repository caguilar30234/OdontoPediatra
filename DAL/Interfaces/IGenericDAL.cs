using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericDAL<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool RemoveRange(TEntity entity);
        bool Remove(TEntity entity);
    }
}
