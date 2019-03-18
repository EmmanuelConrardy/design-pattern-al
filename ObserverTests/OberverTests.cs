using NUnit.Framework;
using Observer;

namespace ObserverTests
{
    [TestFixture]
    public class OberverTests
    {
        [Test]
        public void Observer_Teacher_Teach_And_CheckIfStudentIsListening_Return_False_When_A_StudentSleeping()
        {
            //Arrange
            var teacher = new Teacher("Me"); // subject
            teacher.Attach(new StudentSleeping("Raph")); // observer
            teacher.Attach(new StudentAwake("Leo"));

            //Act
            teacher.Teach(); //Notify

            //Assert
            Assert.IsFalse(teacher.CheckIfStudentIsListening());

        }

        //Todo 1 :
        //Creer un test avec tous les �tudiants Awake

        //Todo 2 :
        //Creer un �tudiant affam� (StudentHungry) qui �coute une fois sur deux que le Teacher Teach()
        //�crire le test associ�s en premier
    }
}
