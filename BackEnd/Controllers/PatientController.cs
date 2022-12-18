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
    public class PatientController : ControllerBase
    {
        private IPatientDAL patientDAL;
        public PatientController()
        {
            patientDAL = new PatientDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        PatientModel Convertir(Patient patient)
        {

            return new PatientModel
            {
                PatientId= patient.PatientId,
                Identification = patient.Identification,
                Name= patient.Name,
                LastName= patient.LastName,
                Age= patient.Age,
                EducationId= patient.EducationId
            };

        }

        Patient Convertir(PatientModel patient)
        {

            return new Patient
            {
                PatientId = patient.PatientId,
                Identification = patient.Identification,
                Name = patient.Name,
                LastName = patient.LastName,
                Age = patient.Age,
                EducationId = patient.EducationId
            };

        }
        #endregion


        #region Consultar
        // GET: api/<AdviceController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Patient> patients;
            patients = patientDAL.GetAll();

            List<PatientModel> result = new List<PatientModel>();
            foreach (Patient patient in patients)
            {
                result.Add(Convertir(patient));
            }
            return new JsonResult(result);
        }

        // GET api/<AdviceController>/5
        [HttpGet("{id}", Name = "GetPatient")]
        public JsonResult Get(int id)
        {
            Patient patient = patientDAL.Get(id);

            return new JsonResult(Convertir(patient));
        }
        #endregion

        #region Agregar
        // POST api/<AdviceController>
        [HttpPost]
        public JsonResult Post([FromBody] PatientModel patient)
        {
            try
            {
                patientDAL.Add(Convertir(patient));
                return new JsonResult(Convertir(patient));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<PatientController>/5
        [HttpPut]
        public JsonResult Put([FromBody] PatientModel patient)
        {
            try
            {
                patientDAL.Update(Convertir(patient));
                return new JsonResult(Convertir(patient));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Patient patient = new Patient { PatientId = id };
                patientDAL.Remove(patient);
                return new JsonResult(patient);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
