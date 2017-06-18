using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Models.Cart
{
    public class CartAtributes
    {
        public Product.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}