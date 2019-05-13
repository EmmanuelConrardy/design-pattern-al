using System;
using System.Collections.Generic;
using Xunit;

namespace Decorator
{
    #region without_design
    public class Coffee_Decorator_Without_Design {
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
            //Here we abuse of the inheritence
            //we should "Add Milk" dynamicaly.
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
    public class Coffee_Decorator_With_Design {

        [Fact]
        public void Decorator_Chocolate_With_Milk_WitDesign()
        {
            var coffee = new WithMilk(new Chocolat());

            var cost = coffee.GetCost();
            var description = coffee.GetDescription();

            Assert.Equal(4.99, cost);
            Assert.Equal("Chocolat, milk", description);
        }

        [Fact]
        public void Decorator_Chocolat_With_Sugar(){
            //Arrange
            var chocolat = new WithSugar(new Chocolat());

            //Act
            var cost = chocolat.GetCost();
            var description = chocolat.GetDescription();

            //Assert
            Assert.Equal(3.99, cost);
            Assert.Equal("Chocolat, sugar", description);
        }

        [Fact]
        public void Decorator_NewFunctionnality(){
            //Arrange
            var chocolat = new WithSugar(new Chocolat());

            //Act
            var message = chocolat.NewFunctionnality();

            //Assert
            Assert.Equal("hello", message);
        }
    }

    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    #endregion

    public class WithMilk : Condiment {
        public WithMilk(ICoffee coffee) : base(coffee) {
            cost = 1;
            name = "milk";
        }
    }

    public class WithSugar : Condiment
    {
        public WithSugar(ICoffee coffee) : base(coffee){
            cost = 0;
            name = "sugar";
        }
    }

    public abstract class Condiment : ICoffee {

        private ICoffee coffee;
        public double cost { get; set; }
        public String name;
        public Condiment(ICoffee Coffee) {
            coffee = Coffee;
        }

        public string GetDescription() {
            return coffee.GetDescription() + ", " + name;
        }
        public double GetCost() {
            return coffee.GetCost() + cost;
        }

        //This is a new responsability
        public string NewFunctionnality(){
            return "hello";
        }
    }

    public class Chocolat : ICoffee
    {
        public double GetCost()
        {
            return 3.99;
        }

        public string GetDescription()
        {
            return "Chocolat";
        }
    }
}
