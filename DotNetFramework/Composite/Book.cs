namespace Composite
{
    public class Book
    {
        public Book(decimal price)
        {
            Price = price;
        }

        public decimal Price { get; internal set; }
    }

    //Can we find an abstraction here ?

    public class Phone
    {
        public Phone(decimal price)
        {
            Price = price;
        }

        public decimal Price { get; internal set; }
    }
}