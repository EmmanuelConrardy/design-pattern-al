using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Facade
{
    public class CuisineTest
    {
        [Fact]
        public void Facade_without_design()
        {
            /* client part */
            var coldAppID = 1;
            var hotEntreeID = 2;
            var drinkID = 3;
            /************* */

            var chief = new Chief("Foo");

            //place the order ("Passer la commande")
            var coldPrep = new ColdPrep();
            var bar = new Bar();
            var hotPrep = new HotPrep();

            Console.WriteLine("{0} places order for cold app #" + coldAppID.ToString()
                               + ", hot entree #" + hotEntreeID.ToString()
                               + ", and drink #" + drinkID.ToString() + ".", chief.Name);

            Order order = new Order();

            order.Appetizer = coldPrep.PrepDish(coldAppID);
            order.Entree = hotPrep.PrepDish(hotEntreeID);
            order.Drink = bar.PrepDish(drinkID);
        }

         [Fact]
        public void Facade_with_design()
        {
            /* client part */
            var coldAppID = 1;
            var hotEntreeID = 2;
            var drinkID = 3;
            /************* */

            var chief = new Chief("Foo");

            //our new simple interface to place the order
            var server = new Server();
            server.PlaceOrder(chief,coldAppID,hotEntreeID,drinkID);
        }
    }
}

//Example from "daily design pattern" of Matthew P Jones
namespace Facade
{
    /// <summary>
    /// All items sold in the restaurant must inherit from this.
    /// </summary>
    public class FoodItem { public int DishID; }

    /// <summary>
    /// Each section of the kitchen must implement this interface.
    /// </summary>
    public interface KitchenSection
    {
        FoodItem PrepDish(int DishID);
    }

    /// <summary>
    /// Orders placed by chief.
    /// </summary>
    public class Order
    {
        public FoodItem Appetizer { get; set; }
        public FoodItem Entree { get; set; }
        public FoodItem Drink { get; set; }
    }

    /// <summary>
    /// Chief of the restaurant
    /// </summary>
    public class Chief
    {
        private string _name;
        public Chief(string name)
        {
            this._name = name;
        }
        public string Name
        {
            get { return _name; }
        }
    }

    /// <summary>
    /// A division of the kitchen.
    /// </summary>
    public class ColdPrep : KitchenSection
    {
        public FoodItem PrepDish(int dishID)
        {
            Console.WriteLine("Cold Prep is preparing Appetizer #" + dishID);
            //Go prep the appetizer
            return new FoodItem()
            {
                DishID = dishID
            };
        }
    }

    /// <summary>
    /// A division of the kitchen.
    /// </summary>
    public class HotPrep : KitchenSection
    {
        public FoodItem PrepDish(int dishID)
        {
            Console.WriteLine("Hot Prep is preparing Entree #" + dishID);
            //Go prep the entree
            return new FoodItem()
            {
                DishID = dishID
            };
        }
    }

    /// <summary>
    /// A division of the kitchen.
    /// </summary>
    public class Bar : KitchenSection

    {
        public FoodItem PrepDish(int dishID)
        {
            Console.WriteLine("The Bar is preparing Drink #" + dishID);
            //Go mix the drink
            return new FoodItem()

            {
                DishID = dishID
            };
        }
    }

    /// <summary>
    /// The actual "Facade" class, which hides the complexity of the KitchenSection classes.
    /// After all, there's no reason a patron should order each part of their meal individually.
    /// </summary>
    public class Server
    {
        private ColdPrep _coldPrep = new ColdPrep();
        private Bar _bar = new Bar();
        private HotPrep _hotPrep = new HotPrep();

        public Order PlaceOrder(Chief patron, int coldAppID, int hotEntreeID, int drinkID)
        {
            Console.WriteLine("{0} places order for cold app #" + coldAppID.ToString()
                                + ", hot entree #" + hotEntreeID.ToString()
                                + ", and drink #" + drinkID.ToString() + ".", patron.Name);

            Order order = new Order();

            order.Appetizer = _coldPrep.PrepDish(coldAppID);
            order.Entree = _hotPrep.PrepDish(hotEntreeID);
            order.Drink = _bar.PrepDish(drinkID);

            return order;
        }
    }
}