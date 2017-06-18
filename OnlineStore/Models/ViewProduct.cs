using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class ViewProduct
    {
        public IEnumerable<Product.Product> Prods { get; set; }
        public Paging PG { get; set; }
        public string CurrentCategory { get; set; }
    }
}