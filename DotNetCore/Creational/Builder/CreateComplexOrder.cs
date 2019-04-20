using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BuilderPattern
{
    public class CreateComplexOrder
    {
        #region Without design
        [Fact]
        public void Use_Builder_Without_Design_Pattern()
        {
            //You can instanciate it like this
            var order = new Order(){
                Tax = new Tax(){
                    Rate = 20,
                    Country = 2 // UK
                },
                Items = new List<Item>(){
                    new Item(){
                        Price = 10,
                        Id = 1,
                        Name = "plate"
                    }
                },
                Address = new Address(){
                    AddressLine = "2 backer street",
                    Zipcode = "KJ87C0",
                    City = "London",
                    Country = 2
                }
            };

            //Or like this
            var tax = new Tax(){
                                Rate = 20,
                                Country = 1 // FR
                            };
            var items = new List<Item>(){
                                new Item(){
                                    Price = 10,
                                    Id = 1,
                                    Name = "Plate"
                                }};
            var address = new Address(){
                                AddressLine = "2 backer street",
                                Zipcode = "KJ87C0",
                                City = "London",
                                Country = 2
                            };

            var orderSecondByTelescopicConstructor = new Order(tax,items,address){
            };

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

        #region With Design

        //An fluent interface with all the "steps" to build our object
        //We return the interface after each step to create a kind of "fluent" build
        public interface IOrderBuilder
        {
            IOrderBuilder BuildTax(int tax, int country);
            IOrderBuilder BuildItems(params Item[] items);
            IOrderBuilder BuildAddress(string addressLine, string Zipcode, string city, int country);
            Order Build();
        }

        //A concrete class with methods
        public class OrderBuilder : IOrderBuilder
        {
            private Order _order;

            public OrderBuilder()
            {
                _order = new Order();
            }

            public IOrderBuilder BuildAddress(string addressLine, string Zipcode, string city, int country)
            {
                _order.Address = new Address(addressLine,Zipcode, city, country);
                return this;
            }

            public IOrderBuilder BuildItems(params Item[] items)
            {
                _order.Items = items.ToList();
                return this;
            }

            public IOrderBuilder BuildTax(int tax, int country)
            {
                _order.Tax = new Tax(tax,country);
                return this;
            }

             public Order Build()
            {
                return _order;
            }
        }

        //An accessor for the builder
        private OrderBuilder _orderBuilder => new OrderBuilder();
        
        [Fact]
        public void Use_Builder_With_Design_Pattern()
        {
            var order = _orderBuilder
                            .BuildTax(20, 2)
                            .BuildItems(NewItem("plate", 10, 1))
                            .BuildAddress("2 backer street", "KJ87C0", "London", 2)
                            .Build();
          
            var orderSecond = _orderBuilder
                            .BuildTax(20, 2)
                            .BuildItems(
                                NewItem("plate", 10, 1), 
                                NewItem("bottle",2,1)
                             )
                            .BuildAddress("2 backer street", "KJ87C0", "London", 2)
                            .Build();
            

            //It is more readable and copy paste is not a problem anymore
            //Change in the creation is simple ! play with it
            //The down side it's it need a lot of code / effort to implement this
        }

        //A small factory
        private static Item NewItem(string name, decimal price, int id)
        {
            return new Item(name, price, id);
        }
        #endregion

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
            public Order(Tax tax, List<Item> items, Address address)
            {
                Tax = tax;
                Items = items;
                Address = address;
            }

            public Tax Tax {get; set;}
            public List<Item> Items {get; set;}
            public Address Address {get; set;}
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