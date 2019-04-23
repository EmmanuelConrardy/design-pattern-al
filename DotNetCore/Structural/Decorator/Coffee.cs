using System;
using System.Collections.Generic;
using Xunit;

namespace Decorator
{
    #region without_design
    [Fact]
    public void Decorator_Espresso_WithoutDesign()
    {
        var coffee = new Espresso();

        var result = coffee.GetCost();

        Assert.Equals(2.99, result);
    }

    [Fact]
    public void Decorator_EspressoWithMilk_WithoutDesign()
    {
        var coffee = new EspressoWithMilk();

        var result = coffee.GetCost();

        Assert.Equals(3.99, result);
    }
    public class Filtered
    {
        public string GetDescription()
        {
            return "Filtered with care";
        }
    
        public double GetCost()
        {
            return 1.99;
        }
    }
    
    public class Espresso
    {
        public string GetDescription()
        {
            return "Espresso made with care";
        }
    
        public double GetCost()
        {
            return 2.99;
        }
    }

    public class EspressoWithMilk
    {
        public string GetDescription()
        {
            return "Espresso made with care, with milk";
        }
    
        public double GetCost()
        {
            return 3.99;
        }
    }
    #endregion

    #region with_design
    
    [Fact]
    public void Decorator_Expresoo_Chocolate_WitDesign()
    {
        var coffee = new ChocolateDecorator(new Espresso());

        var result = coffee.GetCost();

        AssemblyLoadEventArgs.Equals(2.99, result);
    }
    
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    public abstract class CondimentDecorator : ICoffee
    {
        ICoffee _coffee;
    
        protected string _name = "undefined condiment";
        protected double _price = 0.0;
    
        public CondimentDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }
    
        public string GetDescription()
        {
            return string.Format("{0}, {1}", _coffee.GetDescription(), _name);
        }
    
        public double GetCost()
        {
            return _coffee.GetCost() + _price;
        }
    }
    
    public class MilkDecorator : CondimentDecorator
    {
        public MilkDecorator(ICoffee coffee)
            :base(coffee)
        {
            _name = "Milk";
            _price = 1;
        }
    }
 
    public class ChocolateDecorator : CondimentDecorator
    {
        public ChocolateDecorator(ICoffee coffee)
            :base(coffee)
        {
            _name = "Chocolate";
            _price = 2;
        }
    }
    #endregion
}