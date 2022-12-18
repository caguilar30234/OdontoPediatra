using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class TreatmentPatientDALImpl : ITreatmentPatientDAL
    {
        OdontoPediatraContext context;


        /// <summary>
        /// Empty constructor returns Database context
        /// </summary>
        public TreatmentPatientDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        /// <summary>
        /// Constructor recibes Database context as parameter
        /// </summary>
        /// <param name="odontoPediatraContext"></param>
        public TreatmentPatientDALImpl(OdontoPediatraContext odontoPediatraContextContext)
        {
            this.context = odontoPediatraContextContext;
        }

        public bool Add(TreatmentPatient entity)
        {
            try
            {
                using (UnidadDeTrabajo<TreatmentPatient> unidad = new UnidadDeTrabajo<TreatmentPatient>(context))
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

        public TreatmentPatient Get(int TreatmentId)
        {
            try
            {
                TreatmentPatient treatmentPatient;
                using (UnidadDeTrabajo<TreatmentPatient> unidad = new UnidadDeTrabajo<TreatmentPatient>(context))
                {
                    treatmentPatient = unidad.genericDAL.Get(TreatmentId);
                }
                return treatmentPatient;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TreatmentPatient> GetAll()
        {
            try
            {
                IEnumerable<TreatmentPatient> treatmentPatients;
                using (UnidadDeTrabajo<TreatmentPatient> unidad = new UnidadDeTrabajo<TreatmentPatient>(context))
                {
                    treatmentPatients = unidad.genericDAL.GetAll();
                }
                return treatmentPatients;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(TreatmentPatient entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TreatmentPatient> unidad = new UnidadDeTrabajo<TreatmentPatient>(context))
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

        public bool RemoveRange(TreatmentPatient entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(TreatmentPatient treatmentPatient)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TreatmentPatient> unidad = new UnidadDeTrabajo<TreatmentPatient>(context))
                {
                    unidad.genericDAL.Update(treatmentPatient);
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
