namespace Composite
{
    public class Order
    {
        public Order()
        {
            BoxeHead = new BoxContainer();
        }

        public Billing Billing { get; set; }

        public decimal Price
        {
            get
            {
                return BoxeHead.Price;
            }
        }

        public decimal ProductPrice
        {
            get
            {
                return BoxeHead.ProductPrice;
            }
        }

        public Box BoxeHead { get; set; }
    }
}