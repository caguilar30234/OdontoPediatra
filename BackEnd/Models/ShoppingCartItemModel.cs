using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;

namespace BackEnd.Models
{
    public class ShoppingCartItemModel
    {
        public int ShoppingCartItemId { get; set; }
        public Treatment Treatment { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
