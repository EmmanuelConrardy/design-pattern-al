using System;
using System.Collections.Generic;
using Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompositeTests
{
    [TestClass]
    public class BoxesCompositeTests
    {
        private Box NoBoxes => new Box();

        [TestInitialize]
        public void Setup()
        {
        }
        [TestMethod]
        public void Order_With_No_Boxes_Should_Return_Price_Equal_Zero()
        {
            //Arrange
            var order = new Order(); // head
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
            var order = new Order(); // head
            order.Billing = new Billing();

            var box = new Box(); // container
            box.Product = new Book(price: 10); // set leaf
            order.Boxes = box;

            //Act
            var result = order.Price;

            //Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Order_With_Composite_Of_Boxes_Should_Return_50()
        {
            //Arrange
            var order = new Order(); // head
            order.Billing = new Billing();

            var boxContainer = new Box(); // Container 
            var BookLeafOne = new Book(price: 10); // Leaf

            var boxLeaf = new Box(); // Container 
            boxLeaf.Product = BookLeafOne;

            var boxLeafTwo = new Box();
            var BookLeafTwo = new Book(price: 40); // leaf
            boxLeafTwo.Product = BookLeafTwo;

            boxContainer.AddBox(boxLeaf);
            boxContainer.AddBox(boxLeafTwo);

            order.Boxes = boxContainer;

            //Act
            var result = order.Price;

            //Assert
            Assert.AreEqual(50, result);
        }

        //Ecrire un test avec une commande contenant 2 Box
        //Dans chaque boite nous avons 2 Box.
        //Dans les deux première boite il y a respectivement deux Livres de 10 et 20 € 
        //Dans les deux autres boites il n'y a pas de livres 
        //mais des téléphones (Phone) de 40 € et 60€

        // les "Book" sont de type "editorial"
        // les "Phone" sont de type "technique"

        //Créer le test représentant ce problème
        //Ajouter le model manquant, définir une abstraction Product
        //Changer le model Box pour utiliser l'abstraction

        [TestMethod]
        public void Order_With_Two_Book_And_Two_Phone_Return_1550()
        {
            //Arrange
            var order = new Order(); // head
            order.Billing = new Billing();

            var boxHead = new Box(); // Container 
            var BookLeafOne = new Book(price: 10); // Leaf

            var boxLeaf = new Box(); // Container 
            boxLeaf.Product = BookLeafOne;

            var boxLeafTwo = new Box();
            var BookLeafTwo = new Book(price: 40); // leaf
            boxLeafTwo.Product = BookLeafTwo;

            var boxPhoneLeaf = new Box(); // Container

            var boxContainerPhone = new Box(); // Phone 1
            var phoneLeafOne = new Phone(price: 1000);
            boxContainerPhone.Product = phoneLeafOne;

            var boxContainerPhoneTwo = new Box(); // Phone 2
            var phoneLeafTwo = new Phone(price: 500);
            boxContainerPhoneTwo.Product = phoneLeafTwo;
            var boxBook = new Box();

            boxBook.AddBox(boxLeaf);
            boxBook.AddBox(boxLeafTwo);

            boxPhoneLeaf.AddBox(boxContainerPhone);
            boxPhoneLeaf.AddBox(boxContainerPhoneTwo);

            boxHead.AddBox(boxPhoneLeaf);
            boxHead.AddBox(boxBook);

            order.Boxes = boxHead;




            //A  ct
            var result = order.Price;

            //Assert
            Assert.AreEqual(1550, result);

            //Arrange

            //Create composite

            //Act

            //Get Price

            //Assert

            //Check price return 130
        }

        //TODO next
        //create a test qui retourne le prix des produits techniques.

        [TestMethod]
        public void Return_Price_Of_Technical_Products()
        {
            var order = new Order(); // head

            var boxContainerPhone = new Box(); // Phone 1
            var phoneLeafOne = new Phone(price: 1000);
            boxContainerPhone.Product = phoneLeafOne;
            
            var boxContainerBook = new Box(); // Book 1
            var bookLeafOne = new Book(price: 1000);
            boxContainerBook.Product = bookLeafOne;

            var headBox = new Box();
            headBox.AddBox(boxContainerPhone);
            headBox.AddBox(boxContainerBook);

            order.Boxes = headBox;

            //A  ct
            var result = order.TechnicalPrice;

            //Assert
            Assert.AreEqual(1000, result);
            
        }
    }
}
