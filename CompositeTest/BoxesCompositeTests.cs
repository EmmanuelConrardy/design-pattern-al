using System;
using System.Collections.Generic;
using Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompositeTests
{
    [TestClass]
    public class BoxesCompositeTests
    {
        private Box NoBoxes => new BoxContainer();

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
            order.BoxeHead = NoBoxes;

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

            var box = new BoxLeaf(); // leaf
            box.Book = new Book(10);
            order.BoxeHead = box;

            //Act
            var result = order.Price;

            //Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Order_With_Composite_Of_Boxes_Should_Return_50()
        {
            //Arrange
            var order = new Order();

            var boxhead = new BoxContainer(); // head / Container 

            var boxLeaf = aBoxLeaf()
                .WithBookOfPrice(10)
                .Build();

            var boxLeafTwo = new BoxLeaf();
            boxLeafTwo.Book = new Book(price: 40); ;

            boxhead.AddBox(boxLeaf);
            boxhead.AddBox(boxLeafTwo);

            order.BoxeHead = boxhead;

            //Act
            var result = order.Price;

            //Assert
            Assert.AreEqual(50, result);
        }

        private BoxLeafBuilder aBoxLeaf()
        {
            return new BoxLeafBuilder();
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

        //Make it pass change the model if needed
        [TestMethod]
        public void Order_With_Two_Book_And_Two_Phone_Return_130()
        {
            //Arrange
            var order = new Order();

            var boxhead = new BoxContainer(); // head 

            //Book Branch
            var boxOfBook = new BoxContainer();
            var boxLeafBookOne = aBoxLeaf()
                .WithBookOfPrice(10)
                .Build();
            var boxLeafBookTwo = aBoxLeaf()
               .WithBookOfPrice(40)
               .Build();
            boxOfBook.AddBox(boxLeafBookOne);
            boxOfBook.AddBox(boxLeafBookTwo);

            //Phone branch
            var boxOfPhone = new BoxContainer();
            var boxLeafPhoneOne = aBoxLeaf()
                .WithPhoneOfPrice(100)
                .Build();
            var boxLeafPhoneTwo = aBoxLeaf()
               .WithPhoneOfPrice(400)
               .Build();

            boxOfPhone.AddBox(boxLeafPhoneOne);
            boxOfPhone.AddBox(boxLeafPhoneTwo);

            boxhead.AddBox(boxOfBook);
            boxhead.AddBox(boxOfPhone);

            order.BoxeHead = boxhead;

            //Act
            var result = order.Price;

            //Assert
            Assert.AreEqual(550, result);

        }

        //TODO next
        //create a test qui retourne le prix des produits techniques.

        [TestMethod]
        public void ReNameMe()
        {

        }

    }

    internal class BoxLeafBuilder
    {
        private BoxLeaf box {get; set; }
        private Book Book { get; set; }
        public Phone Phone { get; private set; }

        public BoxLeafBuilder()
        {
            box = new BoxLeaf();
        }

        public BoxLeafBuilder WithBookOfPrice(decimal price)
        {
            Book = new Book(price);
            return this;
        }

        public BoxLeaf Build()
        {
            box.Book = Book;
            box.Phone = Phone;
            return box;
        }

        public BoxLeafBuilder WithPhoneOfPrice(decimal price)
        {
            Phone = new Phone(price);
            return this;
        }
    }
}
