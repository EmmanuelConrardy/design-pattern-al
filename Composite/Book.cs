namespace Composite
{
    public class Book : Product
    {
        public Book(int price) : base(price)
        {
            Type = "editorial";
        }
    }

    //Can we find an abstraction here ?

    public class Phone : Product
    {
        
        public Phone(int price) : base(price)
        {
            Type = "technique";
        }
    }

    public abstract class Product
    {
        public string Type { get; set; }
        public Product(int price)
        {
            Price = price;
        }

        public int Price { get; internal set; }
    }
}