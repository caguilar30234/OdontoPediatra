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
    public class DoctorDALImpl : IDoctorDAL
    {
        OdontoPediatraContext context;
        private UnidadDeTrabajo<Doctor> unidad;

        public DoctorDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        public DoctorDALImpl(OdontoPediatraContext _context)
        {
            this.context = _context;
        }
        public bool Add(Doctor entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Doctor>(context))
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

        public Doctor Get(int DoctorId)
        {
            try
            {
                Doctor doctor;
                using (unidad = new UnidadDeTrabajo<Doctor>(context))
                {
                    doctor = unidad.genericDAL.Get(DoctorId);
                }
                return doctor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Doctor> GetAll()
        {
            try
            {
                IEnumerable<Doctor> doctors = null;
                using (unidad = new UnidadDeTrabajo<Doctor>(context))
                {
                    doctors = unidad.genericDAL.GetAll();
                }
                return doctors;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Doctor entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Doctor> unidad = new UnidadDeTrabajo<Doctor>(context))
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

        public bool RemoveRange(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Doctor doctor)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Doctor> unidad = new UnidadDeTrabajo<Doctor>(context))
                {
                    unidad.genericDAL.Update(doctor);
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
