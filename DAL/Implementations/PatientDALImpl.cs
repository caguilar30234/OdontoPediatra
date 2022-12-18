using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class PatientDALImpl : IPatientDAL
    {
        OdontoPediatraContext context;


        /// <summary>
        /// Empty constructor returns Database context
        /// </summary>
        public PatientDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        /// <summary>
        /// Constructor recibes Database context as parameter
        /// </summary>
        /// <param name="odontoPediatraContext"></param>
        public PatientDALImpl(OdontoPediatraContext odontoPediatraContext)
        {
            this.context = odontoPediatraContext;
        }

        public bool Add(Patient entity)
        {
            try
            {
                using (UnidadDeTrabajo<Patient> unidad = new UnidadDeTrabajo<Patient>(context))
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

        public Patient Get(int PatientId)
        {
            try
            {
                Patient patient;
                using (UnidadDeTrabajo<Patient> unidad = new UnidadDeTrabajo<Patient>(context))
                {
                    patient = unidad.genericDAL.Get(PatientId);
                }
                return patient;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Patient> GetAll()
        {
            try
            {
                IEnumerable<Patient> patients;
                using (UnidadDeTrabajo<Patient> unidad = new UnidadDeTrabajo<Patient>(context))
                {
                    patients = unidad.genericDAL.GetAll();
                }
                return patients;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Patient entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Patient> unidad = new UnidadDeTrabajo<Patient>(context))
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

        public bool RemoveRange(Patient entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Patient patient)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Patient> unidad = new UnidadDeTrabajo<Patient>(context))
                {
                    unidad.genericDAL.Update(patient);
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
