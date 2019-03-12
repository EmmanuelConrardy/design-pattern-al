using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeTests
{
    public class Box
    {
        private List<Product> _products;

        public Box()
        {
            _products = new List<Product>();
        }

        public int Price
        {
            get
            {
                return _products.Sum(p => p.Price);
            }
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);

        }
    }
}