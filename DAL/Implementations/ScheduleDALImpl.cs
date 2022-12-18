using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ScheduleDALImpl : IScheduleDAL
    {
        OdontoPediatraContext context;


        /// <summary>
        /// Empty constructor returns Database context
        /// </summary>
        public ScheduleDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        /// <summary>
        /// Constructor recibes Database context as parameter
        /// </summary>
        /// <param name="odontoPediatraContext"></param>
        public ScheduleDALImpl(OdontoPediatraContext odontoPediatraContext)
        {
            this.context = odontoPediatraContext;
        }

        public bool Add(Schedule entity)
        {
            try
            {
                using (UnidadDeTrabajo<Schedule> unidad = new UnidadDeTrabajo<Schedule>(context))
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

        public Schedule Get(int ScheduleId)
        {
            try
            {
                Schedule schedule;
                using (UnidadDeTrabajo<Schedule> unidad = new UnidadDeTrabajo<Schedule>(context))
                {
                    schedule = unidad.genericDAL.Get(ScheduleId);
                }
                return schedule;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Schedule> GetAll()
        {
            try
            {
                IEnumerable<Schedule> schedules;
                using (UnidadDeTrabajo<Schedule> unidad = new UnidadDeTrabajo<Schedule>(context))
                {
                    schedules = unidad.genericDAL.GetAll();
                }
                return schedules;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Schedule entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Schedule> unidad = new UnidadDeTrabajo<Schedule>(context))
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

        public bool RemoveRange(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Schedule schedule)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Schedule> unidad = new UnidadDeTrabajo<Schedule>(context))
                {
                    unidad.genericDAL.Update(schedule);
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
