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
    public class AdviceController : ControllerBase
    {
        private IAdviceDAL adviceDAL;

        public AdviceController()
        {
            adviceDAL = new AdviceDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        AdviceModel Convertir(Advice advice)
        {

            return new AdviceModel
            {
                AdviceId = advice.AdviceId,
                DoctorId = advice.DoctorId,
                Name = advice.Name,
                Description = advice.Description,
                Picture = advice.Picture
            };

        }

        Advice Convertir(AdviceModel advice)
        {

            return new Advice
            {
                AdviceId = (int)advice.AdviceId,
                DoctorId = advice.DoctorId,
                Name = advice.Name,
                Description = advice.Description,
                Picture = advice.Picture
            };

        }
        #endregion


        #region Consultar
        // GET: api/<AdviceController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Advice> advices;
            advices = adviceDAL.GetAll();

            List<AdviceModel> result = new List<AdviceModel>();
            foreach (Advice advice in advices)
            {
                result.Add(Convertir(advice));
            }
            return new JsonResult(result);
        }

        // GET api/<AdviceController>/5
        [HttpGet("{id}", Name = "GetAdvice")]
        public JsonResult Get(int id)
        {
            Advice advice = adviceDAL.Get(id);

            return new JsonResult(Convertir(advice));
        }
        #endregion

        #region Agregar
        // POST api/<AdviceController>
        [HttpPost]
        public JsonResult Post([FromBody] AdviceModel advice)
        {
            try
            {
                Advice entity = Convertir(advice);

                adviceDAL.Add(entity);
                return new JsonResult(Convertir(advice));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<AdviceController>/5
        [HttpPut]
        public JsonResult Put([FromBody] AdviceModel advice)
        {
            try
            {
                adviceDAL.Update(Convertir(advice));

                return new JsonResult(Convertir(advice));
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
                Advice advice = new Advice { AdviceId = id };
                adviceDAL.Remove(advice);
                return new JsonResult(advice);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
