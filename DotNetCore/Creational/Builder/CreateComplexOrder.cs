using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BuilderPattern
{
    public class CreateComplexOrder
    {
        #region Without design
        [Fact]
        public void Use_Builder_Without_Design_Pattern()
        {
            var tax = new Tax(){
                    Rate = 20,
                    Country = 2 // UK
                };
                var items = new List<Item>(){
                    new Item(){
                        Price = 10,
                        Id = 1,
                        Name = "plate"
                    }
                };
                var address = new Address(){
                    AddressLine = "2 backer street",
                    Zipcode = "KJ87C0",
                    City = "London",
                    Country = 2
                };
           
            
           
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("foo");
            builder.AppendLine("bar");
            builder.Replace("foo","bar");
            var result = builder.ToString();

            //You can instanciate it like this
            var order = new Order(){
                Tax = tax,
                Items = items,
                Address = address
            };

            var orderBuilder = new OrderBuilder();
            order = orderBuilder
                .WithTax(tax)
                .WithItems(items)
                .WithAddress(address)
                .Build();

            Assert.Equal(address, order.Address);
            Assert.Equal(tax, order.Tax);
            Assert.Equal(items, order.Items);


           var orderbuild = new OrderBuilder();
            var orderSecondByTelescopicConstructor = new Order(tax,items,address,null);
            
            orderSecondByTelescopicConstructor = 
            orderbuild.WithTax(tax)
                    .WithItems(items)
                    .WithTax(tax)
                    .Build();

            //Or like this...
            var orderThirdByTelescopicConstructor = new Order(tax,items){
                Address = new Address(){
                    AddressLine = "3 rue des pyramides",
                                Zipcode = "75001",
                                City = "PARIS",
                                Country = 2
                }
            };

            //A lot of new operator everywhere look like creational responsability is not respected
            //We can see some duplication as well If we continue change the code will be harder
            //We can see some telescopic constructor, get rid of it !
            //Take a look at the region with design and refactor this test
        }
        #endregion

      public interface IOrderBuilder{
           IOrderBuilder WithTax(Tax tax);

           IOrderBuilder WithItems(List<Item> items);

           IOrderBuilder WithAddress(Address address);

            IOrderBuilder WithBillingAddress(Address billingAddress);
           Order Build();

      }

        public class OrderBuilder : IOrderBuilder
        {
        
            public OrderBuilder(){
                Order = new Order();
            }

            private Order Order { get; set; }

            public Order Build()
            {
                return Order;
            }

            public IOrderBuilder WithAddress(Address address)
            {
                Order.Address = address;
                return this;
            }

            public IOrderBuilder WithItems(List<Item> items)
            {
                Order.Items = items;
                return this;
            }

            public IOrderBuilder WithTax(Tax tax)
            {
               Order.Tax = tax;
               return this;
            }

            public IOrderBuilder WithBillingAddress(Address billingAddress)
            {
                Order.BillingAddress = billingAddress;
                return this;
            }
        }
        //Our models
        public class Order{
            public Order(){ }
            public Order(Tax tax)
            {
                Tax = tax;
            }
            public Order(Tax tax, List<Item> items)
            {
                Tax = tax;
                Items = items;
            }
            public Order(Tax tax, List<Item> items, Address address, Address billingAddress)
            {
                Tax = tax;
                Items = items;
                Address = address;
                BillingAddress = billingAddress;
            }

            public Tax Tax {get; set;}
            public List<Item> Items {get; set;}
            public Address Address {get; set;}
            public Address BillingAddress {get; set;} 
        }
        public class Tax{
            public Tax() {}
            public Tax(int rate, int country)
            {
                Rate = rate;
                Country = country;
            }

            public decimal Rate {get; set;}
            public decimal Country {get; set;}
        }
        public class Item{
            public Item(){}
            public Item(string name, decimal price, int id)
            {
                Name = name;
                Price = price;
                Id = id;
            }

            public decimal Price {get; set;}
            public int Id {get; set;}
            public string Name {get; set;}
        }
        public class Address{
            public Address(){}
            public Address(string addressLine, string zipcode, string city, int country)
            {
                AddressLine = addressLine;
                Zipcode = zipcode;
                City = city;
                Country = country;
            }

            public string AddressLine {get; set;}
            public string  Zipcode {get; set;}
            public string  City {get; set;}
            public int Country {get; set;}
        }
    }
}