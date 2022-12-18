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
    public class TreatmentDALImpl : ITreatmentDAL
    {
        OdontoPediatraContext context;


        /// <summary>
        /// Empty constructor returns Database context
        /// </summary>
        public TreatmentDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        /// <summary>
        /// Constructor recibes Database context as parameter
        /// </summary>
        /// <param name="odontoPediatraContext"></param>
        public TreatmentDALImpl(OdontoPediatraContext odontoPediatraContext)
        {
            this.context = odontoPediatraContext;
        }

        public bool Add(Treatment entity)
        {
            try
            {
                using (UnidadDeTrabajo<Treatment> unidad = new UnidadDeTrabajo<Treatment>(context))
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

        public Treatment Get(int TreatId)
        {
            try
            {
                Treatment treatment;
                using (UnidadDeTrabajo<Treatment> unidad = new UnidadDeTrabajo<Treatment>(context))
                {
                    treatment = unidad.genericDAL.Get(TreatId);
                }
                return treatment;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Treatment> GetAll()
        {
            try
            {
                IEnumerable<Treatment> treatments;
                using (UnidadDeTrabajo<Treatment> unidad = new UnidadDeTrabajo<Treatment>(context))
                {
                    treatments = unidad.genericDAL.GetAll();
                }
                return treatments;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Treatment entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Treatment> unidad = new UnidadDeTrabajo<Treatment>(context))
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

        public bool RemoveRange(Treatment entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Treatment user)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Treatment> unidad = new UnidadDeTrabajo<Treatment>(context))
                {
                    unidad.genericDAL.Update(user);
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
