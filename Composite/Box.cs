using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public class Box
    {
        //Maybe be we can be more abstract
        public Book Book { get; set; } 
        private List<Box> _boxs;

        public Box()
        {
            _boxs = new List<Box>();
        }

        public int Price
        {
            get
            {
                if (Book != null) //hit leaf
                    return Book.Price;

                return _boxs.Sum(p => p.Price);
            }
        }

        public void AddBox(Box box)
        {
            _boxs.Add(box);

        }
    }
}