using System;
using Xunit;

namespace ChainOfResponsibility
{
    public class ApproveOrder
    {
        [Fact]
        public void ApproveOrder_WitoutDesign()
        {
            //Arrange
            PurchaseOrder purchase = new PurchaseOrder(1, 20, 69, "Spices");
            var orderValidation = new OrderValidation();

            //Act
            orderValidation.ValidateOrder(purchase);

            //Assert
            Assert.True(purchase.HasbeenValidated);
        }

        [Fact]
        public void AprroveOrder_With_Design()
        {
            //Create the chain links
            Approver jennifer = new HeadChef();
            Approver mitchell = new PurchasingManager();
            Approver olivia = new GeneralManager();

            //Create the chain can be change at runtime
            jennifer.SetSupervisor(mitchell);
            mitchell.SetSupervisor(olivia);

            // Generate and process purchase requests
            var p = new PurchaseOrder(2, 300, 1389, "Fresh Veggies");
            
            //Act
            jennifer.ValidatePurchaseOrder(p);

            //Assert
            Assert.True(p.HasbeenValidated);
        }
    }

   /// <summary>
   /// With no design, we can't change it at runtime, it will be easy 
   /// to break the Single Responsability Principle
   /// </summary>
   public class OrderValidation
    {
        public void ValidateOrder(PurchaseOrder purchase)
        {
            if (purchase.Price < 1000)
            {
                Console.WriteLine("{0} approved purchase request #{1}",
                    "HeadChef", purchase.RequestNumber);
                purchase.HasbeenValidated = true;
            }
            else if (purchase.Price < 2500)
            {
                Console.WriteLine("{0} approved purchase request #{1}",
                    "PurchasingManager", purchase.RequestNumber);
                purchase.HasbeenValidated = true;
            }
            else if (purchase.Price < 10000)
            {
                Console.WriteLine("{0} approved purchase request #{1}",
                    "GeneralManager", purchase.RequestNumber);
                purchase.HasbeenValidated = true;
            }
            else
            {
                Console.WriteLine(
                    "Purchase request #{0} requires an executive meeting!",
                    purchase.RequestNumber);
            }
        }
    }

    /// <summary>
    /// The Handler abstract class.  Every class which inherits from this will be responsible for a kind of request for the restaurant.
    /// </summary>
    public abstract class Approver
    {
        protected Approver Supervisor;

        public void SetSupervisor(Approver supervisor)
        {
            this.Supervisor = supervisor;
        }

        public abstract void ValidatePurchaseOrder(PurchaseOrder purchase);
    }

    /// <summary>
    /// A concrete Handler class
    /// </summary>
    public class HeadChef : Approver
    {
        public override void ValidatePurchaseOrder(PurchaseOrder purchase)
        {
            if (purchase.Price < 1000)
            {
                Console.WriteLine("{0} approved purchase request #{1}",
                    this.GetType().Name, purchase.RequestNumber);
                purchase.HasbeenValidated = true;
            }
            else if (Supervisor != null)
            {
                 Supervisor.ValidatePurchaseOrder(purchase);
            }
        }
    }

    /// <summary>
    /// A concrete Handler class
    /// </summary>
    public class PurchasingManager : Approver
    {
        public override void ValidatePurchaseOrder(PurchaseOrder purchase)
        {
            if (purchase.Price < 2500)
            {
                Console.WriteLine("{0} approved purchase request #{1}",
                    this.GetType().Name, purchase.RequestNumber);
                purchase.HasbeenValidated = true;
            }
            else if (Supervisor != null)
            {
                Supervisor.ValidatePurchaseOrder(purchase);
            }
        }
    }

    /// <summary>
    /// A concrete Handler class
    /// </summary>
    public class GeneralManager : Approver
    {
        public override void ValidatePurchaseOrder(PurchaseOrder purchase)
        {
            if (purchase.Price < 10000)
            {
                Console.WriteLine("{0} approved purchase request #{1}",
                    this.GetType().Name, purchase.RequestNumber);
                purchase.HasbeenValidated = true;
            }
            else
            {
                Console.WriteLine(
                    "Purchase request #{0} requires an executive meeting!",
                    purchase.RequestNumber);
            }
        }
    }

    /// <summary>
    /// The details of the purchase request.  
    /// </summary>
    public class PurchaseOrder
    {

        // Constructor
        public PurchaseOrder(int number, double amount, double price, string name)
        {
            RequestNumber = number;
            Amount = amount;
            Price = price;
            Name = name;

            Console.WriteLine("Purchase request for " + name + " (" + amount + " for $" + price.ToString() + ") has been submitted.");
        }

        public bool HasbeenValidated { get; set; }
        public int RequestNumber { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}

