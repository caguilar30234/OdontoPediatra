using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ClinicDALImpl : IClinicDAL
    {
        OdontoPediatraContext context;
        private UnidadDeTrabajo<Clinic> unidad;

        public ClinicDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        public ClinicDALImpl(OdontoPediatraContext _context)
        {
            this.context = _context;
        }

        public bool Add(Clinic entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Clinic>(context))
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

        public Clinic Get(int ClinicId)
        {
            try
            {
                Clinic Clinic;
                using (unidad = new UnidadDeTrabajo<Clinic>(context))
                {
                    Clinic = unidad.genericDAL.Get(ClinicId);
                }
                return Clinic;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Clinic> GetAll()
        {
            try
            {
                IEnumerable<Clinic> Clinics = null;
                using (unidad = new UnidadDeTrabajo<Clinic>(context))
                {
                    Clinics = unidad.genericDAL.GetAll();
                }
                return Clinics;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Clinic entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Clinic> unidad = new UnidadDeTrabajo<Clinic>(context))
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

        public bool RemoveRange(Clinic entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Clinic Clinic)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Clinic> unidad = new UnidadDeTrabajo<Clinic>(context))
                {
                    unidad.genericDAL.Update(Clinic);
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
