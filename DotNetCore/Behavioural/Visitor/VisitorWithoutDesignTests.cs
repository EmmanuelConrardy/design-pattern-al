using System;
using System.Collections.Generic;
using Xunit;

namespace Visitor.refactoring
{
    public class VisitorWithoutDesignTests
    {
        [Fact]
        public void Export_Without_Design()
        {
            Cat cat = new Cat();
            Bacteria bacteria = new Bacteria();
            Pen pen = new Pen();

            var catExport = cat.Export();
            var bacteriaExport = bacteria.Export();
            var penExport = pen.Export();
            
            Assert.Equal( $"The age of the cat is 6",catExport);
            Assert.Equal( $"The name of the bacteria is Actinopolyspora halophila",bacteriaExport);
            Assert.Equal( $"The brand of the pen is Mont Blanc",penExport);
        }
        [Fact]
        public void Export_Visitor_Design()
        {
            var visitor = new ExtractVisitor();

            Cat cat = new Cat();
            Bacteria bacteria = new Bacteria();
            Pen pen = new Pen();

            cat.Accept(visitor);
            bacteria.Accept(visitor);
            pen.Accept(visitor);
            
            Assert.Equal( $"The age of the cat is 6",visitor.CatExport);
            Assert.Equal( $"The name of the bacteria is Actinopolyspora halophila",visitor.BacteriaExport);
            Assert.Equal( $"The brand of the pen is Mont Blanc",visitor.PenExport);
        }
    }

    public interface IVisitable{
        void Accept(IVisitor visitor);
    }

    public interface IVisitor{
        void Visit(IVisitable visitable);
        void Visit(Cat cat);
        void Visit(Bacteria bacteria);
        void Visit(Pen pen);
    }

    public class ExtractVisitor : IVisitor
    {
        public string CatExport { get; internal set; }
        public string BacteriaExport { get; internal set; }
        public string PenExport { get; internal set; }

        public void Visit(Cat cat){
            CatExport = "The age of the cat is " + cat.Age;
        }

        public void Visit(Bacteria bacteria)
        {
            BacteriaExport = "The name of the bacteria is " + bacteria.Name;
        }

        public void Visit(Pen pen)
        {
            PenExport = "The brand of the pen is " + pen.Brand;
        }

        public void Visit(IVisitable visitable)
        {
            throw new NotImplementedException();
        }
    }

    public interface IExportable{
        string Export();
    }

    public class Cat : IExportable, IVisitable
    {
        public int Age = 6;

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string Export()
        {
            return $"The age of the cat is {Age}";
        }
    }

    public class Bacteria : IExportable, IVisitable
    {
        public string Name = "Actinopolyspora halophila";

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string Export()
        {
           return $"The name of the bacteria is {Name}";
        }
    }

    public class Pen : IExportable, IVisitable
    {
        public string Brand = "Mont Blanc";

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string Export()
        {
           return $"The brand of the pen is {Brand}";
        }
    }
}
