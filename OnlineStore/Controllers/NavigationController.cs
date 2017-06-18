using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models.Product;

namespace OnlineStore.Controllers
{
    public class NavigationController : Controller
    {
        private IProduct iprod;

        public NavigationController(IProduct ipr)
        {
            iprod = ipr;
        }

        public PartialViewResult CategoryMenu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = iprod.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}