using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Models.Shipping;

namespace OnlineStore.Models.Orders
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart.Cart cart, ShippingDetails shippingDetails);
    }
}
