using NUnit.Framework;
using Singleton;

namespace SingletonTests
{
    [TestFixture]
    public class SingletonBadTests
    {
        /// <summary>
        /// THIS IS WRONG DO NOT WRITE THIS KIND OF TEST
        /// </summary>
        [Test]
        public void SingletonBasic_Add_Message_Then_Get_Message_Really_Bad_Test()
        {
            //Arrange
            var client = new Client();

            //Act
            //It will execute our singleton
            var result = client.Run();

            //Assert
            //Can't even check the result it depend of the current time
            Assert.IsNotNull(result);
        }

        //This is wrong, what happen if our repoInstance.WriteMessage(); write something in database.
        //This test will be executed thousand of time so we will insert thousand of rows in database

        //One way to solve this is to stubs it
        [Test]
        public void SingletonBasic_Add_Message_Then_Get_Message_Not_Really_Bad_Test()
        {
            //Arrange
            var client = new ClientTestable();

            //Act
            var result = client.Run();

            //Assert
            Assert.AreEqual("someMessage", result);
        }
    }

    class ClientTestable : ClientAfter
    {
        protected override string WriteAndGetMessages()
        {
            return "someMessage";
        }
    }
}
