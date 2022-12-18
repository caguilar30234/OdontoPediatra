using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class PatientDoctorDALImpl : IPatientDoctorDAL
    {
        OdontoPediatraContext context;
        private UnidadDeTrabajo<PatientDoctor> unidad;


        /// <summary>
        /// Empty constructor returns Database context
        /// </summary>
        public PatientDoctorDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        /// <summary>
        /// Constructor recibes Database context as parameter
        /// </summary>
        /// <param name="odontoPediatraContext"></param>
        public PatientDoctorDALImpl(OdontoPediatraContext odontoPediatraContext)
        {
            this.context = odontoPediatraContext;
        }

        public bool Add(PatientDoctor entity)
        {
            try
            {
                using (UnidadDeTrabajo<PatientDoctor> unidad = new UnidadDeTrabajo<PatientDoctor>(context))
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

        public PatientDoctor Get(int patientDoctorId)
        {
            try
            {
                PatientDoctor patientUser;
                using (UnidadDeTrabajo<PatientDoctor> unidad = new UnidadDeTrabajo<PatientDoctor>(context))
                {
                    patientUser = unidad.genericDAL.Get(patientDoctorId);
                }
                return patientUser;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<PatientDoctor> GetAll()
        {
            try
            {
                IEnumerable<PatientDoctor> patientDoctors;
                using (UnidadDeTrabajo<PatientDoctor> unidad = new UnidadDeTrabajo<PatientDoctor>(context))
                {
                    patientDoctors = unidad.genericDAL.GetAll();
                }
                return patientDoctors;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(PatientDoctor entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<PatientDoctor> unidad = new UnidadDeTrabajo<PatientDoctor>(context))
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

        public bool RemoveRange(PatientDoctor entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(PatientDoctor patientDoctor)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<PatientDoctor> unidad = new UnidadDeTrabajo<PatientDoctor>(context))
                {
                    unidad.genericDAL.Update(patientDoctor);
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
