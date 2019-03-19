using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public interface Box
    {
        decimal Price { get; }

        void AddBox(Box box);

    }

    public class BoxContainer : Box
    {
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

        public void AddBox(params Box[] boxes)
        {
            foreach (var box in boxes)
            {
                _boxs.Add(box);
            }
        }
    }
    public class BoxLeaf : Box
    {
        public Product Product { get; set; }

        public BoxLeaf(){ }

        public decimal Price
        {
            get
            {
                return Product.Price;
            }
        }

        public void AddBox(Box box)
        {
            //do nothing
        }
    }
}