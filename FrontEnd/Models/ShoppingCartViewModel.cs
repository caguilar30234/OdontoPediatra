using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ShoppingCartViewModel
    {
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartViewModel> shoppingCartItems { get; set; }
    }
}
