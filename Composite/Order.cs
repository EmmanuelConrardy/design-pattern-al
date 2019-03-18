namespace Composite
{
    public class Order
    {
        public Order()
        {
            Boxes = new Box();
        }

        public Billing Billing { get; set; }

        public decimal Price
        {
            get
            {
                return Boxes.Price;
            }
        }
        public Box Boxes { get; set; }

        public decimal TechnicalPrice
        {
            get
            {
                return Boxes.TechnicalPrice;
            }
        }
    }
}