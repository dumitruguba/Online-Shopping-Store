using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models;
using OnlineStore.Models.Product;
using OnlineStore.Models.Product.EF;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _prod = new EFProduct();

        private int pageSize = 4;

        // GET: Product
        public ActionResult List(string category, int page = 1)
        {
            ViewProduct model = new ViewProduct
            {
                Prods = _prod.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PG = new Paging
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? _prod.Products.Count() :
                        _prod.Products.Count(p => p.Category == category)
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}