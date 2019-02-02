using LifeBoatUnitTest.Logic.PersonClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeBoatUnitTest.Logic.Test
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests

        [TestMethod]
        [Owner("Dev1")]
        public void AreEqualTest()
        {
            //Arrange
            string str1 = "Igor";
            string str2 = "Igor";

            //Assert
            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Dev2")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            //Arrange
            string str1 = "Igor";
            string str2 = "igor";

            //Assert
            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("Dev3")]
        public void AreNotEqualTest()
        {
            //Arrange
            string str1 = "Igor";
            string str2 = "John";

            //Assert
            Assert.AreNotEqual(str1, str2);
        }

        #endregion

        #region AreSame/AreNotSame Tests

        [TestMethod]
        [Owner("Dev1")]
        public void AreSameTest()
        {
            //Arrange
            var file1 = new FileProcess();
            var file2 = file1;

            //Assert
            Assert.AreSame(file1, file2);
        }

        [TestMethod]
        [Owner("Dev2")]
        public void AreNotSameTest()
        {
            //Arrange
            var file1 = new FileProcess();
            var file2 = new FileProcess();

            //Assert
            Assert.AreNotSame(file1, file2);
        }

        #endregion

        #region IsInstanceOfType/IsNotInstanceOfType Tests

        [TestMethod]
        [Owner("Dev1")]
        public void IsInstanceOfTypeTest()
        {
            //Arrange
            var personManager = new PersonManager();
            Person person;

            //Act
            person = personManager.CreatePerson("Igor", "Gomes", true);

            //Assert
            Assert.IsInstanceOfType(person, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Dev1")]
        public void IsNotInstanceOfTypeTest()
        {
            //Arrange
            var personManager = new PersonManager();
            Person person;

            //Act
            person = personManager.CreatePerson("Igor", "Gomes", false);

            //Assert
            Assert.IsNotInstanceOfType(person, typeof(Supervisor));
        }

        #endregion

        #region IsNull Test

        [TestMethod]
        [Owner("Dev2")]
        public void IsNullTest()
        {
            //Arrange
            var personManager = new PersonManager();
            Person person;

            //Act
            person = personManager.CreatePerson(string.Empty, "Gomes", false);

            //Assert
            Assert.IsNull(person);
        }

        #endregion
    }
}
