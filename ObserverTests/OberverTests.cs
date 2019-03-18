using Microsoft.VisualStudio.TestTools.UnitTesting;
using Observer;

namespace ObserverTests
{
    [TestClass]
    public class OberverTests
    {
        [TestMethod]
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
        //Creer un test avec tous les étudiants Awake

        //Todo 2 :
        //Creer un étudiant affamé (StudentHungry) qui écoute une fois sur deux que le Teacher Teach()
        //écrire le test associés en premier
    }
}
