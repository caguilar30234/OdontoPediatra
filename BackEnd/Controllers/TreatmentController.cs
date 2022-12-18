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
    public class TreatmentController : ControllerBase
    {
        private ITreatmentDAL TreatmentDAL;
        public TreatmentController()
        {
            TreatmentDAL = new TreatmentDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        TreatmentModel Convertir(Treatment Treatment)
        {

            return new TreatmentModel
            {
                TreatmentId = Treatment.TreatmentId,
                Name = Treatment.Name,
                Description= Treatment.Description,
                BaseCost= Treatment.BaseCost
            };

        }

        Treatment Convertir(TreatmentModel Treatment)
        {

            return new Treatment
            {
                TreatmentId = Treatment.TreatmentId,
                Name = Treatment.Name,
                Description = Treatment.Description,
                BaseCost = Treatment.BaseCost
            };

        }
        #endregion


        #region Consultar
        // GET: api/<AdviceController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Treatment> Treatments;
            Treatments = TreatmentDAL.GetAll();

            List<TreatmentModel> result = new List<TreatmentModel>();
            foreach (Treatment Treatment in Treatments)
            {
                result.Add(Convertir(Treatment));
            }
            return new JsonResult(result);
        }

        // GET api/<AdviceController>/5
        [HttpGet("{id}", Name = "GetTreatment")]
        public JsonResult Get(int id)
        {
            Treatment Treatment = TreatmentDAL.Get(id);

            return new JsonResult(Convertir(Treatment));
        }
        #endregion

        #region Agregar
        // POST api/<AdviceController>
        [HttpPost]
        public JsonResult Post([FromBody] TreatmentModel Treatment)
        {
            try
            {
                TreatmentDAL.Add(Convertir(Treatment));
                return new JsonResult(Convertir(Treatment));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<TreatmentController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TreatmentModel Treatment)
        {
            try
            {
                TreatmentDAL.Update(Convertir(Treatment));
                return new JsonResult(Convertir(Treatment));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<TreatmentController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Treatment Treatment = new Treatment { TreatmentId = id };
                TreatmentDAL.Remove(Treatment);
                return new JsonResult(Treatment);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
