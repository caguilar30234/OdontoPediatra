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
    public class ClinicController : ControllerBase
    {
        private IClinicDAL ClinicDAL;
        public ClinicController()
        {
            ClinicDAL = new ClinicDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        ClinicModel Convertir(Clinic Clinic)
        {

            return new ClinicModel
            {
                ClinicId = Clinic.ClinicId,
                DoctorId = Clinic.DoctorId,
                ClinicName = Clinic.ClinicName,
                ClinicPhone=Clinic.ClinicPhone,
                ClinicAddress=Clinic.ClinicAddress,
                ProvinceId=Clinic.ProvinceId
            };

        }

        Clinic Convertir(ClinicModel clinic)
        {

            return new Clinic
            {
                ClinicId = clinic.ClinicId,
                DoctorId = clinic.DoctorId,
                ClinicName = clinic.ClinicName,
                ClinicPhone = clinic.ClinicPhone,
                ClinicAddress = clinic.ClinicAddress,
                ProvinceId = clinic.ProvinceId
            };

        }
        #endregion


        #region Consultar
        // GET: api/<AdviceController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Clinic> Clinics;
            Clinics = ClinicDAL.GetAll();

            List<ClinicModel> result = new List<ClinicModel>();
            foreach (Clinic Clinic in Clinics)
            {
                result.Add(Convertir(Clinic));
            }
            return new JsonResult(result);
        }

        // GET api/<AdviceController>/5
        [HttpGet("{id}", Name = "GetClinic")]
        public JsonResult Get(int id)
        {
            Clinic Clinic = ClinicDAL.Get(id);

            return new JsonResult(Convertir(Clinic));
        }
        #endregion

        #region Agregar
        // POST api/<AdviceController>
        [HttpPost]
        public JsonResult Post([FromBody] ClinicModel Clinic)
        {
            try
            {
                Clinic entity = Convertir(Clinic);
                ClinicDAL.Add(entity);

                return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<ClinicController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ClinicModel Clinic)
        {
            try
            {
                ClinicDAL.Update(Convertir(Clinic));
                return new JsonResult(Convertir(Clinic));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<ClinicController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Clinic Clinic = new Clinic { ClinicId = id };
                ClinicDAL.Remove(Clinic);
                return new JsonResult(Clinic);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
