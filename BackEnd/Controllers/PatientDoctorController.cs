using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDoctorController : ControllerBase
    {
        private IPatientDoctorDAL PatientDoctorDAL;
        public PatientDoctorController()
        {
            PatientDoctorDAL = new PatientDoctorDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        PatientDoctorModel Convertir(PatientDoctor patientDoctor)
        {

            return new PatientDoctorModel
            {
                PatientDoctorId = patientDoctor.PatientDoctorId,
                DoctorId = patientDoctor.DoctorId,
                PatientId = patientDoctor.PatientId
            };

        }

        PatientDoctor Convertir(PatientDoctorModel patientDoctor)
        {

            return new PatientDoctor
            {
                PatientDoctorId = patientDoctor.PatientDoctorId,
                DoctorId = patientDoctor.DoctorId,
                PatientId = patientDoctor.PatientId
            };

        }
        #endregion


        #region Consultar
        // GET: api/<PatientDoctorController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<PatientDoctor> patientDoctors;
            patientDoctors = PatientDoctorDAL.GetAll();

            List<PatientDoctorModel> result = new List<PatientDoctorModel>();
            foreach (PatientDoctor patientDoctor in patientDoctors)
            {
                result.Add(Convertir(patientDoctor));
            }
            return new JsonResult(result);
        }

        // GET api/<PatientDoctorController>/5
        [HttpGet("{id}", Name = "GetPatientUser")]
        public JsonResult Get(int id)
        {
            PatientDoctor patientDoctor = PatientDoctorDAL.Get(id);

            return new JsonResult(Convertir(patientDoctor));
        }
        #endregion

        #region Agregar
        // POST api/<PatientUserController>
        [HttpPost]
        public JsonResult Post([FromBody] PatientDoctorModel patientDoctor)
        {
            try
            {
                PatientDoctorDAL.Add(Convertir(patientDoctor));
                return new JsonResult(Convertir(patientDoctor));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<PatientDoctorController>/5
        [HttpPut]
        public JsonResult Put([FromBody] PatientDoctorModel patientDoctor)
        {
            try
            {
                PatientDoctorDAL.Update(Convertir(patientDoctor));
                return new JsonResult(Convertir(patientDoctor));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<PatientDoctorController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                PatientDoctor patientDoctor = new PatientDoctor { PatientDoctorId = id };
                PatientDoctorDAL.Remove(patientDoctor);
                return new JsonResult(patientDoctor);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
