using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public class Box
    {
        //Maybe be we can be more abstract
        public Product Product { get; set; }

        private List<Box> _boxs;

        public Box()
        {
            _boxs = new List<Box>();
        }

        public int Price
        {
            get
            {
                if (Product != null) //hit leaf
                    return Product.Price;

                return _boxs.Sum(p => p.Price);
            }
        }

        public int TechnicalPrice
        {
            get
            {
                if (Product != null && Product.Type == "technique")
                    return Product.Price;

                return _boxs.Sum(p => p.TechnicalPrice);
            }
        }


        public void AddBox(Box box)
        {
            _boxs.Add(box);

        }
    }
}