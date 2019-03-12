using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompositeTests
{
    [TestClass]
    public class BoxesCompositeTests
    {
        private List<Box> NoBoxes => new List<Box>();

        [TestInitialize]
        public void Setup()
        {
        }
        [TestMethod]
        public void Order_With_No_Boxes_Should_Return_Price_Equal_Zero()
        {
            //Arrange
            var order = new Order();
            order.Billing = new Billing();
            order.Boxes = NoBoxes;

            //Act
            var result = order.Price;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Order_With_One_Box_Price_Of_Ten_Should_Return_Price_Equal_Ten()
        {
            //Arrange
            var order = new Order();
            order.Billing = new Billing();

            var box = new Box();
            var product = new Product(price: 10);
            box.AddProduct(product);
            order.Boxes.Add(box);

            //Act
            var result = order.Price;

            //Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Order_With_Two_Box_Price_Of_Ten_Should_Return_Price_Equal_Twenty()
        {
            //Arrange
            var order = new Order();
            order.Billing = new Billing();

            var box = new Box();
            var product = new Product(price: 10);
            box.AddProduct(product);
            box.AddProduct(product);
            order.Boxes.Add(box);

            //Act
            var result = order.Price;

            //Assert
            Assert.AreEqual(20, result);
        }
    }
}
