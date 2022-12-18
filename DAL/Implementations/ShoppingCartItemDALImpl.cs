using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShoppingCartItemDALImpl : IShoppingCartItemDAL
    {
        OdontoPediatraContext context;
        private UnidadDeTrabajo<ShoppingCartItem> unidad;

        public ShoppingCartItemDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        public ShoppingCartItemDALImpl(OdontoPediatraContext _context)
        {
            this.context = _context;
        }

        public bool Add(ShoppingCartItem entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<ShoppingCartItem>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public ShoppingCartItem Get(int ShoppingCartItemId)
        {
            try
            {
                ShoppingCartItem ShoppingCartItem;
                using (unidad = new UnidadDeTrabajo<ShoppingCartItem>(context))
                {
                    ShoppingCartItem = unidad.genericDAL.Get(ShoppingCartItemId);
                }
                return ShoppingCartItem;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ShoppingCartItem> GetAll()
        {
            try
            {
                IEnumerable<ShoppingCartItem> ShoppingCartItems = null;
                using (unidad = new UnidadDeTrabajo<ShoppingCartItem>(context))
                {
                    ShoppingCartItems = unidad.genericDAL.GetAll();
                }
                return ShoppingCartItems;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(ShoppingCartItem entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<ShoppingCartItem> unidad = new UnidadDeTrabajo<ShoppingCartItem>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }

        public bool RemoveRange(ShoppingCartItem entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<ShoppingCartItem> unidad = new UnidadDeTrabajo<ShoppingCartItem>(context))
                {
                    unidad.genericDAL.RemoveRange(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
            return result;
        }

        public bool Update(ShoppingCartItem ShoppingCartItem)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<ShoppingCartItem> unidad = new UnidadDeTrabajo<ShoppingCartItem>(context))
                {
                    unidad.genericDAL.Update(ShoppingCartItem);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return result;
        }
    }
}
