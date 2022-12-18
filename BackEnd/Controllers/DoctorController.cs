using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorDAL doctorDAL;

        public DoctorController()
        {
            doctorDAL = new DoctorDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        DoctorModel Convertir(Doctor doctor)
        {

            return new DoctorModel
            {
                DoctorId = doctor.DoctorId,
                Identification = doctor.Identification,
                Name = doctor.Name,
                LastName = doctor.LastName
            };

        }

        Doctor Convertir(DoctorModel doctor)
        {

            return new Doctor
            {
                DoctorId = doctor.DoctorId,
                Identification = doctor.Identification,
                Name = doctor.Name,
                LastName = doctor.LastName
            };

        }
        #endregion


        #region Consultar
        // GET: api/<DoctorController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Doctor> doctors;
            doctors = doctorDAL.GetAll();

            List<DoctorModel> result = new List<DoctorModel>();
            foreach (Doctor doctor in doctors)
            {
                result.Add(Convertir(doctor));
            }
            return new JsonResult(result);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}", Name = "GetDoctor")]
        public JsonResult Get(int id)
        {
            Doctor doctor = doctorDAL.Get(id);

            return new JsonResult(Convertir(doctor));
        }
        #endregion

        #region Agregar
        // POST api/<DoctorController>
        [HttpPost]
        public JsonResult Post([FromBody] DoctorModel doctor)
        {
            try
            {
                Doctor entity = Convertir(doctor);

                doctorDAL.Add(entity);
                return new JsonResult(Convertir(doctor));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<DoctorController>/5
        [HttpPut]
        public JsonResult Put([FromBody] DoctorModel doctor)
        {
            try
            {
                doctorDAL.Update(Convertir(doctor));

                return new JsonResult(Convertir(doctor));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Doctor doctor = new Doctor { DoctorId = id };
                doctorDAL.Remove(doctor);
                return new JsonResult(doctor);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
}
