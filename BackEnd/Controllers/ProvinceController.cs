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
    public class ProvinceController : ControllerBase
    {
        private IProvinceDAL ProvinceDAL;
        public ProvinceController()
        {
            ProvinceDAL = new ProvinceDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        ProvinceModel Convertir(Province Province)
        {

            return new ProvinceModel
            {
                ProvinceId = Province.ProvinceId,
                ProvinceName= Province.ProvinceName
            };

        }

        Province Convertir(ProvinceModel Province)
        {

            return new Province
            {
                ProvinceId = Province.ProvinceId,
                ProvinceName= Province.ProvinceName
            };

        }
        #endregion


        #region Consultar
        // GET: api/<AdviceController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Province> Provinces;
            Provinces = ProvinceDAL.GetAll();

            List<ProvinceModel> result = new List<ProvinceModel>();
            foreach (Province Province in Provinces)
            {
                result.Add(Convertir(Province));
            }
            return new JsonResult(result);
        }

        // GET api/<AdviceController>/5
        [HttpGet("{id}", Name = "GetProvince")]
        public JsonResult Get(int id)
        {
            Province Province = ProvinceDAL.Get(id);

            return new JsonResult(Convertir(Province));
        }
        #endregion

        #region Agregar
        // POST api/<AdviceController>
        [HttpPost]
        public JsonResult Post([FromBody] ProvinceModel Province)
        {
            try
            {
                ProvinceDAL.Add(Convertir(Province));
                return new JsonResult(Convertir(Province));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<ProvinceController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ProvinceModel Province)
        {
            try
            {
                ProvinceDAL.Update(Convertir(Province));
                return new JsonResult(Convertir(Province));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<ProvinceController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Province Province = new Province { ProvinceId = id };
                ProvinceDAL.Remove(Province);
                return new JsonResult(Province);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
