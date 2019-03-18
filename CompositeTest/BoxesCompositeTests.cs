using System;
using System.Collections.Generic;
using Composite;
using NUnit.Framework;

namespace CompositeTests
{
    [TestFixture]
    public class BoxesCompositeTests
    {
        private Box NoBoxes => new Box();

        [SetUp]
        public void Setup()
        {
        }
        [Test]
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

        [Test]
        public void Order_With_One_Box_Price_Of_Ten_Should_Return_Price_Equal_Ten()
        {
            //Arrange
            var order = new Order(); // head
            order.Billing = new Billing();

            var box = new Box(); // container
            box.Book = new Book(price: 10); // set leaf
            order.Boxes = box;

            //Act
            var result = order.Price;

            //Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Order_With_Composite_Of_Boxes_Should_Return_50()
        {
            //Arrange
            var order = new Order(); // head
            order.Billing = new Billing();

            var boxContainer = new Box(); // Container 
            var BookLeafOne = new Book(price: 10); // Leaf

            var boxLeaf = new Box(); // Container 
            boxLeaf.Book = BookLeafOne;

            var boxLeafTwo = new Box();
            var BookLeafTwo = new Book(price: 40); // leaf
            boxLeafTwo.Book = BookLeafTwo;

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

        [Test]
        public void Order_With_Two_Book_And_Two_Phone_Return_130()
        {
            //Arrange
            
            //Create composite

            //Act

            //Get Price

            //Assert

            //Check price return 130
        }

        //TODO next
        //create a test qui retourne le prix des produits techniques.



    }
}
