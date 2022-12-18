using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentDAL appointmentDAL;

        public AppointmentController()
        {
            appointmentDAL = new AppointmentDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        AppointmentModel Convertir(Appointment appointment)
        {

            return new AppointmentModel
            {
                AppoinmentId = appointment.AppoinmentId,
                PatientId = appointment.PatientId,
                ScheduleId = appointment.ScheduleId,
                Motivo = appointment.Motivo,
                CitaAsignada = appointment.CitaAsignada
            };

        }

        Appointment Convertir(AppointmentModel appointment)
        {

            return new Appointment
            {
                AppoinmentId = appointment.AppoinmentId,
                PatientId = appointment.PatientId,
                ScheduleId = appointment.ScheduleId,
                Motivo = appointment.Motivo,
                CitaAsignada =appointment.CitaAsignada
            };

        }
        #endregion

        #region Consultar
        // GET: api/<AppointmentController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Appointment> appointments;
            appointments = appointmentDAL.GetAll();

            List<AppointmentModel> result = new List<AppointmentModel>();
            foreach (Appointment appointment in appointments)
            {
                result.Add(Convertir(appointment));
            }
            return new JsonResult(result);
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}", Name = "GetAppointment")]
        public JsonResult Get(int id)
        {
            Appointment appointment = appointmentDAL.Get(id);

            return new JsonResult(Convertir(appointment));
        }
        #endregion


        #region Agregar
        // POST api/<AppointmentController>
        [HttpPost]
        public JsonResult Post([FromBody] AppointmentModel appointment)
        {
            try
            {
                appointmentDAL.Add(Convertir(appointment));
                return new JsonResult(Convertir(appointment));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<AppointmentController>/5
        [HttpPut]
        public JsonResult Put([FromBody] AppointmentModel appointment)
        {
            try
            {
                appointmentDAL.Update(Convertir(appointment));
                return new JsonResult(Convertir(appointment));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Appointment appointment = new Appointment { AppoinmentId = id };
                appointmentDAL.Remove(appointment);
                return new JsonResult(appointment);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
