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
    public class ShoppingCartItemController : ControllerBase
    {
        private IShoppingCartItemDAL ShoppingCartItemDAL;  
        public ShoppingCartItemController()
        {
            ShoppingCartItemDAL = new ShoppingCartItemDALImpl(new OdontoPediatraContext());
        }

        #region Convertir
        ShoppingCartItemModel Convertir(ShoppingCartItem shoppingCartItem)
        {

            return new ShoppingCartItemModel
            {
                ShoppingCartItemId = shoppingCartItem.ShoppingCartItemId,
                Treatment = shoppingCartItem.Treatment,
                Amount= shoppingCartItem.Amount,
                ShoppingCartId = shoppingCartItem.ShoppingCartId
            };

        }

        ShoppingCartItem Convertir(ShoppingCartItemModel shoppingCartItem)
        {

            return new ShoppingCartItem
            {
                ShoppingCartItemId = shoppingCartItem.ShoppingCartItemId,
                Treatment = shoppingCartItem.Treatment,
                Amount = shoppingCartItem.Amount,
                ShoppingCartId = shoppingCartItem.ShoppingCartId
            };

        }
        #endregion

        #region Consultar
        // GET: api/<AdviceController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<ShoppingCartItem> ShoppingCartItems;
            ShoppingCartItems = ShoppingCartItemDAL.GetAll();

            List<ShoppingCartItemModel> result = new List<ShoppingCartItemModel>();
            foreach (ShoppingCartItem ShoppingCartItem in ShoppingCartItems)
            {
                result.Add(Convertir(ShoppingCartItem));
            }
            return new JsonResult(result);
        }

        // GET api/<AdviceController>/5
        [HttpGet("{id}", Name = "GetShoppingCartItem")]
        public JsonResult Get(int id)
        {
            ShoppingCartItem ShoppingCartItem = ShoppingCartItemDAL.Get(id);

            return new JsonResult(Convertir(ShoppingCartItem));
        }
        #endregion

        #region Agregar
        // POST api/<AdviceController>
        [HttpPost]
        public JsonResult Post([FromBody] ShoppingCartItemModel ShoppingCartItem)
        {
            try
            {
                ShoppingCartItemDAL.Add(Convertir(ShoppingCartItem));
                return new JsonResult(Convertir(ShoppingCartItem));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<ShoppingCartItemController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ShoppingCartItemModel ShoppingCartItem)
        {
            try
            {
                ShoppingCartItemDAL.Update(Convertir(ShoppingCartItem));
                return new JsonResult(Convertir(ShoppingCartItem));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<ShoppingCartItemController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                ShoppingCartItem ShoppingCartItem = new ShoppingCartItem { ShoppingCartItemId = id };
                ShoppingCartItemDAL.Remove(ShoppingCartItem);
                return new JsonResult(ShoppingCartItem);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
