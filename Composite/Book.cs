namespace Composite
{
    public class Book
    {
        public Book(int price)
        {
            Price = price;
        }

        public int Price { get; internal set; }
    }

    //Can we find an abstraction here ?

    public class Phone
    {
        public Phone(int price)
        {
            Price = price;
        }

        public int Price { get; internal set; }
    }
}