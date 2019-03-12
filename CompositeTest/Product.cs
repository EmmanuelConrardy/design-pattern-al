namespace CompositeTests
{
    public class Product
    {
        public Product(int price)
        {
            Price = price;
        }

        public int Price { get; internal set; }
    }
}