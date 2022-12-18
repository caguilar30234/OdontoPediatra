using System;
using System.Collections.Generic;

namespace Entities
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Treatment Treatment { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
