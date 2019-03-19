namespace Composite
{
    public abstract class Product
    {
        public Product(decimal price)
        {
            Price = price;
        }
        public decimal Price { get; set; }
        public Category Type { get; set; }
    }

    public enum Category
    {
        Technical, Editorial
    }

    public class Book : Product
    {
        public Book(decimal price) : base(price)
        {
            Type = Category.Editorial;
        }
    }

    //Can we find an abstraction here ?

    public class Phone : Product
    {
        public Phone(decimal price) : base(price)
        {
            Type = Category.Technical;
        }
    }
}