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
    public class AppointmentDALImpl : IAppointmentDAL
    {
        OdontoPediatraContext context;


        /// <summary>
        /// Empty constructor returns Database context
        /// </summary>
        public AppointmentDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        /// <summary>
        /// Constructor recibes Database context as parameter
        /// </summary>
        /// <param name="odontoPediatraContext"></param>
        public AppointmentDALImpl(OdontoPediatraContext odontoPediatraContext)
        {
            this.context = odontoPediatraContext;
        }

        public bool Add(Appointment entity)
        {
            try
            {
                using (UnidadDeTrabajo<Appointment> unidad = new UnidadDeTrabajo<Appointment>(context))
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

        public Appointment Get(int AppointmentId)
        {
            try
            {
                Appointment appointment;
                using (UnidadDeTrabajo<Appointment> unidad = new UnidadDeTrabajo<Appointment>(context))
                {
                    appointment = unidad.genericDAL.Get(AppointmentId);
                }
                return appointment;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Appointment> GetAll()
        {
            try
            {
                IEnumerable<Appointment> appointments;
                using (UnidadDeTrabajo<Appointment> unidad = new UnidadDeTrabajo<Appointment>(context))
                {
                    appointments = unidad.genericDAL.GetAll();
                }
                return appointments;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Appointment entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Appointment> unidad = new UnidadDeTrabajo<Appointment>(context))
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

        public bool RemoveRange(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Appointment appointment)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Appointment> unidad = new UnidadDeTrabajo<Appointment>(context))
                {
                    unidad.genericDAL.Update(appointment);
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
