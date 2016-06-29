using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Cart
{
    public class ShoppingCart : IShoppingCart
    {
        public ICollection<IProduct> productList;

        public ShoppingCart()
        {
            // TODO: Implement List
            this.ProductList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
            set { this.productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            this.ProductList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.ProductList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.ProductList.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal res = 0;

            foreach(var p in this.ProductList)
            {
                res += p.Price;
            }

            return res;
        }
    }
}
