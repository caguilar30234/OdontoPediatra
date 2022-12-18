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
    [Authorize(Roles = "odontologo, paciente")]
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentPatientController : ControllerBase
    {
        private ITreatmentPatientDAL TreatmentPatientDAL;
        public TreatmentPatientController()
        {
            TreatmentPatientDAL = new TreatmentPatientDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        TreatmentPatientModel Convertir(TreatmentPatient TreatmentPatient)
        {

            return new TreatmentPatientModel
            {
                TreatmentPatientId = TreatmentPatient.TreatmentPatientId,
                PatientId= TreatmentPatient.PatientId,
                TreatmentId = TreatmentPatient.TreatmentId
            };

        }

        TreatmentPatient Convertir(TreatmentPatientModel TreatmentPatient)
        {

            return new TreatmentPatient
            {
                TreatmentPatientId = TreatmentPatient.TreatmentPatientId,
                PatientId = TreatmentPatient.PatientId,
                TreatmentId = TreatmentPatient.TreatmentId
            };

        }
        #endregion


        #region Consultar
        // GET: api/<AdviceController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<TreatmentPatient> TreatmentPatients;
            TreatmentPatients = TreatmentPatientDAL.GetAll();

            List<TreatmentPatientModel> result = new List<TreatmentPatientModel>();
            foreach (TreatmentPatient TreatmentPatient in TreatmentPatients)
            {
                result.Add(Convertir(TreatmentPatient));
            }
            return new JsonResult(result);
        }

        // GET api/<AdviceController>/5
        [HttpGet("{id}", Name = "GetTreatmentPatient")]
        public JsonResult Get(int id)
        {
            TreatmentPatient TreatmentPatient = TreatmentPatientDAL.Get(id);

            return new JsonResult(Convertir(TreatmentPatient));
        }
        #endregion

        #region Agregar
        // POST api/<AdviceController>
        [HttpPost]
        public JsonResult Post([FromBody] TreatmentPatientModel TreatmentPatient)
        {
            try
            {
                TreatmentPatientDAL.Add(Convertir(TreatmentPatient));
                return new JsonResult(Convertir(TreatmentPatient));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<TreatmentPatientController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TreatmentPatientModel TreatmentPatient)
        {
            try
            {
                TreatmentPatientDAL.Update(Convertir(TreatmentPatient));
                return new JsonResult(Convertir(TreatmentPatient));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<TreatmentPatientController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TreatmentPatient TreatmentPatient = new TreatmentPatient { TreatmentPatientId = id };
                TreatmentPatientDAL.Remove(TreatmentPatient);
                return new JsonResult(TreatmentPatient);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
