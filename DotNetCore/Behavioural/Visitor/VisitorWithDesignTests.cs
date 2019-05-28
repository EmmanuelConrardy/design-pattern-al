using System.Text;
using System;
using Xunit;

namespace Visitor
{
    public class VisitorWithDesignTests
    {
        public readonly string expected = $"Breed : chihuahua\r\nGender : male\r\nColor : red\r\n";

        [Fact]
        public void Export_Without_Design()
        {
            ExtractVisitor visitor = new ExtractVisitor();

            Dog dog = new Dog();
            Human human = new Human();
            Book book = new Book();

            dog.Accept(visitor);
            human.Accept(visitor);
            book.Accept(visitor);
            var result = visitor.Extract.ToString();
            
            Assert.Equal(expected, result);
        }
    }

    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    public class Dog : Mammal, IVisitable
    {
        public String breed = "chihuahua";

        public void Accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Mammal
    {
    }

    public class Human : Mammal, IVisitable
    {
        public String gender = "male";

        public void Accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public class Book : IVisitable
    {
        public String color = "red";

        public void Accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    public interface IVisitor
    {
        void visit(IVisitable o);
        void visit(Dog o);
        void visit(Human o);
        void visit(Book o);
    }

    public class ExtractVisitor : IVisitor
    {
        public StringBuilder Extract;

        public ExtractVisitor()
        {
            Extract = new StringBuilder();
        }
        public void visit(Dog o)
        {
           Extract.AppendLine("Breed : " + o.breed);
        }

        public void visit(Human o)
        {
            Extract.AppendLine("Gender : " + o.gender);
        }

        public void visit(Book o)
        {
            Extract.AppendLine("Color : " + o.color);
        }

        public void visit(IVisitable o)
        {
            Console.WriteLine("Not implemented yet");
        }
    }

}
