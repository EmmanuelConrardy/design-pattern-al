using System;
using System.Collections.Generic;
using Xunit;

namespace Decorator
{
    #region without_design
    public class test {
        [Fact]
        public void Decorator_Espresso_WithoutDesign()
        {
            var coffee = new Espresso();

            var result = coffee.GetCost();

            Assert.Equal(2.99, result);
        }

        [Fact]
        public void Decorator_EspressoWithMilk_WithoutDesign()
        {
            var coffee = new EspressoWithMilk();

            var result = coffee.GetCost();

            Assert.Equal(3.99, result);
        }
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
    public class testDesign{

    [Fact]
    public void Decorator_Expresoo_Chocolate_WitDesign()
    {
        // var coffee = new MilkDecorator(new ChocolateDecorator(new Espresso()));

        // var result = coffee.GetCost();

        // Assert.Equals(4.99, result);
    }
    }
    
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    #endregion

    public class WithMilk : Condiment{
        public WithMilk(){
            cost = 1;
            name = "milk";
        }
    }

    public abstract class Condiment : ICoffee{

        private ICoffee coffee;
        public double cost{get; set;}
        public String name;
        public Condiment(ICoffee Coffee){
            coffee = Coffee;
        }

        public string GetDescription(){
            return coffee.GetDescription() + ", " + name;
        }
        public double GetCost(){
            return coffee.GetCost() + cost;
        }
    }
}
