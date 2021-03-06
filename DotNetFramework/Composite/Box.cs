﻿using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public interface Box
    {
        //Maybe be we can be more abstract
        decimal Price { get; }

        void AddBox(Box box);

    }

    public class BoxContainer : Box //node
    {
        //Maybe be we can be more abstract
        private List<Box> _boxs;

        public BoxContainer()
        {
            _boxs = new List<Box>();
        }

        public decimal Price
        {
            get
            {
                return _boxs.Sum(p => p.Price);
            }
        }

        public void AddBox(Box box)
        {
            _boxs.Add(box);

        }
    }
    public class BoxLeaf : Box//leaf
    {
        //Maybe be we can be more abstract
        public Book Book { get; set; }

        public BoxLeaf(){ }

        public decimal Price
        {
            get
            {
             //bad : ( should do something with the model   
                return Book?.Price ?? Phone.Price;
            }
        }

        public Phone Phone { get; set; }

        public void AddBox(Box box)
        {
            //do nothing
        }
    }
}