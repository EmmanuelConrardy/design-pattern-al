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
        public Box BoxeHead { get; set; }
    }
}