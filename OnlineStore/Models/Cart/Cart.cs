using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Components.DictionaryAdapter;

namespace OnlineStore.Models.Cart
{
    public class Cart
    {
        private List<CartAtributes> cartProds = new EditableList<CartAtributes>();

        public void AddItem(Product.Product product, int quantity)
        {
            CartAtributes prod = cartProds.FirstOrDefault(p => p.Product.ProductId == product.ProductId);
            if (prod == null)
            {
                cartProds.Add(new CartAtributes {Product = product, Quantity = quantity});
            }
            else
            {
                prod.Quantity += quantity;
            }
        }

        public void RemoveItems(Product.Product product)
        {
            cartProds.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public decimal TotalPrice()
        {
            return cartProds.Sum(p => p.Product.Price * p.Quantity);
        }

        public IEnumerable<CartAtributes> Prods
        {
            get { return cartProds;}
        }

        public void Clear()
        {
            cartProds.Clear();
        }
    }

    public class CopCart
    {
        private List<CartAtributes> cartProds = new EditableList<CartAtributes>();

        public void AddItem(Product.Product product, int quantity)
        {
            CartAtributes prod = cartProds.FirstOrDefault(p => p.Product.ProductId == product.ProductId);
            if (prod == null)
            {
                cartProds.Add(new CartAtributes { Product = product, Quantity = quantity });
            }
            else
            {
                prod.Quantity += quantity;
            }
        }

        public void RemoveItems(Product.Product product)
        {
            cartProds.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public decimal TotalPrice()
        {
            return cartProds.Sum(p => p.Product.Price * p.Quantity);
        }

        public IEnumerable<CartAtributes> Prods
        {
            get { return cartProds; }
        }

        public void Clear()
        {
            cartProds.Clear();
        }
    }
}