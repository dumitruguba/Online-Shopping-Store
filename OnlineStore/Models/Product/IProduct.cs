using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Models.Product
{
    public interface IProduct
    {
        IEnumerable<Product> Products { get; }
    }
}
