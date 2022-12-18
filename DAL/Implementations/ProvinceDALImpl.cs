using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProvinceDALImpl : IProvinceDAL
    {
        OdontoPediatraContext context;
        private UnidadDeTrabajo<Province> unidad;

        public ProvinceDALImpl()
        {
            context = new OdontoPediatraContext();
        }

        public ProvinceDALImpl(OdontoPediatraContext _context)
        {
            this.context = _context;
        }

        public bool Add(Province entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Province>(context))
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

        public Province Get(int ProvinceId)
        {
            try
            {
                Province Province;
                using (unidad = new UnidadDeTrabajo<Province>(context))
                {
                    Province = unidad.genericDAL.Get(ProvinceId);
                }
                return Province;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Province> GetAll()
        {
            try
            {
                IEnumerable<Province> Provinces = null;
                using (unidad = new UnidadDeTrabajo<Province>(context))
                {
                    Provinces = unidad.genericDAL.GetAll();
                }
                return Provinces;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Province entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Province> unidad = new UnidadDeTrabajo<Province>(context))
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

        public bool RemoveRange(Province entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Province Province)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Province> unidad = new UnidadDeTrabajo<Province>(context))
                {
                    unidad.genericDAL.Update(Province);
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
