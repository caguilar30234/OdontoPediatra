using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BackEnd.Controllers
{
    [Authorize(Roles = "odontologo")]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleDAL ScheduleDAL;
        public ScheduleController()
        {
            ScheduleDAL = new ScheduleDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        ScheduleModel Convertir(Schedule Schedule)
        {

            return new ScheduleModel
            {
                ScheduleId = Schedule.ScheduleId,
                TimeOfDay= Schedule.TimeOfDay
            };

        }

        Schedule Convertir(ScheduleModel Schedule)
        {

            return new Schedule
            {
                ScheduleId = Schedule.ScheduleId,
                TimeOfDay = Schedule.TimeOfDay
            };

        }
        #endregion


        #region Consultar
        // GET: api/<AdviceController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Schedule> Schedules;
            Schedules = ScheduleDAL.GetAll();

            List<ScheduleModel> result = new List<ScheduleModel>();
            foreach (Schedule Schedule in Schedules)
            {
                result.Add(Convertir(Schedule));
            }
            return new JsonResult(result);
        }

        // GET api/<AdviceController>/5
        [HttpGet("{id}", Name = "GetSchedule")]
        public JsonResult Get(int id)
        {
            Schedule Schedule = ScheduleDAL.Get(id);

            return new JsonResult(Convertir(Schedule));
        }
        #endregion

        #region Agregar
        // POST api/<AdviceController>
        [HttpPost]
        public JsonResult Post([FromBody] ScheduleModel Schedule)
        {
            try
            {
                ScheduleDAL.Add(Convertir(Schedule));
                return new JsonResult(Convertir(Schedule));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<ScheduleController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ScheduleModel Schedule)
        {
            try
            {
                ScheduleDAL.Update(Convertir(Schedule));
                return new JsonResult(Convertir(Schedule));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Schedule Schedule = new Schedule { ScheduleId = id };
                ScheduleDAL.Remove(Schedule);
                return new JsonResult(Schedule);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
