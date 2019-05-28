using System;
using Xunit;

namespace Visitor
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
    }

    public interface IExportable{
        string Export();
    }

    public class Cat : IExportable
    {
        public int Age = 6;
        public string Export()
        {
            return $"The age of the cat is {Age}";
        }
    }

    public class Bacteria : IExportable
    {
        public string Name = "Actinopolyspora halophila";
        public string Export()
        {
           return $"The name of the bacteria is {Name}";
        }
    }

    public class Pen : IExportable
    {
        public string Brand = "Mont Blanc";
        public string Export()
        {
           return $"The brand of the pen is {Brand}";
        }
    }
}
