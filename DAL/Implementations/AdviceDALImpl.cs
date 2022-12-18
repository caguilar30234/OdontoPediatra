using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class AdviceDALImpl : IAdviceDAL
    {
        OdontoPediatraContext context;
        private UnidadDeTrabajo<Advice> unidad;

        public AdviceDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        public AdviceDALImpl(OdontoPediatraContext _context)
        {
            this.context = _context;
        }

        public bool Add(Advice entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Advice>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public Advice Get(int AdviceId)
        {
            try
            {
                Advice advice;
                using (unidad = new UnidadDeTrabajo<Advice>(context))
                {
                    advice = unidad.genericDAL.Get(AdviceId);
                }
                return advice;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Advice> GetAll()
        {
            try
            {
                IEnumerable<Advice> advices = null;
                using (unidad = new UnidadDeTrabajo<Advice>(context))
                {
                    advices = unidad.genericDAL.GetAll();
                }

                return advices;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Advice entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Advice> unidad = new UnidadDeTrabajo<Advice>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }

        public bool RemoveRange(Advice entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Advice advice)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Advice> unidad = new UnidadDeTrabajo<Advice>(context))
                {
                    unidad.genericDAL.Update(advice);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return result;
        }
    }
}
