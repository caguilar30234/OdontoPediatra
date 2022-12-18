using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace DAL.Implementations
{
    internal class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly OdontoPediatraContext context;
        public IGenericDAL<T> genericDAL;

        /// <summary>
        /// Constructor recibes a Database context
        /// </summary>
        /// <returns></returns>
        public UnidadDeTrabajo(OdontoPediatraContext _context)
        {
            context = _context;
            genericDAL = new DALGenericImpl<T>(context);
        }

        /// <summary>
        /// Save changes to database
        /// </summary>
        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }

        }

        /// <summary>
        /// Closes Database connection
        /// </summary>
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
