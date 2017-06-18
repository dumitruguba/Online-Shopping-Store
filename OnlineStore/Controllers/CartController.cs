using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models;
using OnlineStore.Models.Cart;
using OnlineStore.Models.Orders;
using OnlineStore.Models.Product;
using OnlineStore.Models.Shipping;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        private IProduct prod;
        private IOrderProcessor orderProcessor;

        public CartController(IProduct p, IOrderProcessor proc)
        {
            prod = p;
            orderProcessor = proc;
        }

        public ViewResult Index(string url)
        {
            return View(new CartIndexView {Cart = GetCart(), ReturnUrl = url});
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public RedirectToRouteResult AddToCart(int productId, string url)
        {
            Product product = prod.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            
            return RedirectToAction("Index", new {url});
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string url)
        {
            Product product = prod.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                GetCart().RemoveItems(product);
            }

            return RedirectToAction("Index", new {url});
        }

        [HttpGet]
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(ShippingDetails shippingDetails)
        {
            if (!GetCart().Prods.Any())
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(GetCart(), shippingDetails);
                GetCart().Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }


        private Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}