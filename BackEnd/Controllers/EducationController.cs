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
    public class EducationController : ControllerBase
    {
        private IEducationDAL educationDAL;
        public EducationController()
        {
            educationDAL = new EducationDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        EducationModel Convertir(Education education)
        {

            return new EducationModel
            {
                EducationId = education.EducationId,
                Level = education.Level
            };

        }

        Education Convertir(EducationModel education)
        {

            return new Education
            {
                EducationId = education.EducationId,
                Level = education.Level
            };

        }
        #endregion


        #region Consultar
        // GET: api/<EducationController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Education> educations;
            educations = educationDAL.GetAll();

            List<EducationModel> result = new List<EducationModel>();
            foreach (Education education in educations)
            {
                result.Add(Convertir(education));
            }
            return new JsonResult(result);
        }

        // GET api/<EducationController>/5
        [HttpGet("{id}", Name = "GetEducation")]
        public JsonResult Get(int id)
        {
            Education education = educationDAL.Get(id);

            return new JsonResult(Convertir(education));
        }
        #endregion

        #region Agregar
        // POST api/<EducationController>
        [HttpPost]
        public JsonResult Post([FromBody] EducationModel education)
        {
            try
            {
                educationDAL.Add(Convertir(education));
                return new JsonResult(Convertir(education));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<EducationController>/5
        [HttpPut]
        public JsonResult Put([FromBody] EducationModel education)
        {
            try
            {
                educationDAL.Update(Convertir(education));
                return new JsonResult(Convertir(education));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<AdviceController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Education education = new Education { EducationId = id };
                educationDAL.Remove(education);
                return new JsonResult(education);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
