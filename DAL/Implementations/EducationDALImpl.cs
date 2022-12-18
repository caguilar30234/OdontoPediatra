using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EducationDALImpl : IEducationDAL
    {
        OdontoPediatraContext context;


        /// <summary>
        /// Empty constructor returns Database context
        /// </summary>
        public EducationDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        /// <summary>
        /// Constructor recibes Database context as parameter
        /// </summary>
        /// <param name="odontoPediatraContext"></param>
        public EducationDALImpl(OdontoPediatraContext odontoPediatraContext)
        {
            this.context = odontoPediatraContext;
        }

        public bool Add(Education entity)
        {
            try
            {
                using (UnidadDeTrabajo<Education> unidad = new UnidadDeTrabajo<Education>(context))
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

        public Education Get(int EducationId)
        {
            try
            {
                Education education;
                using (UnidadDeTrabajo<Education> unidad = new UnidadDeTrabajo<Education>(context))
                {
                    education = unidad.genericDAL.Get(EducationId);
                }
                return education;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Education> GetAll()
        {
            try
            {
                IEnumerable<Education> educations;
                using (UnidadDeTrabajo<Education> unidad = new UnidadDeTrabajo<Education>(context))
                {
                    educations = unidad.genericDAL.GetAll();
                }
                return educations;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Education entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Education> unidad = new UnidadDeTrabajo<Education>(context))
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

        public bool RemoveRange(Education entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Education education)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Education> unidad = new UnidadDeTrabajo<Education>(context))
                {
                    unidad.genericDAL.Update(education);
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
