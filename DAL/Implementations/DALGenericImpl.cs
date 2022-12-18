using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenericImpl<TEntity> : IGenericDAL<TEntity> where TEntity : class
    {
        protected readonly OdontoPediatraContext Context;
        public DALGenericImpl(OdontoPediatraContext context)
        {
            Context = context;
        }
        public bool Add(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Add(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public TEntity Get(int id)
        {
            try
            {
                return Context.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Context.Set<TEntity>().ToList();
            }
            catch (Exception)
            {

                return null;
            };
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Attach(entity);
                Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool RemoveRange(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().AttachRange(entity);
                Context.Set<TEntity>().RemoveRange(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
