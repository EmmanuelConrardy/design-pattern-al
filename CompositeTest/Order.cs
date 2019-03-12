using System.Collections.Generic;
using System.Linq;

namespace CompositeTests
{
    public class Order
    {
        public Order()
        {
            Boxes = new List<Box>();
        }

        public Billing Billing { get; internal set; }
        public decimal Price
        {
            get
            {
                return Boxes.Sum(b => b.Price);
            }
        }
        public List<Box> Boxes { get; internal set; }
    }
}