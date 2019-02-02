using LifeBoatUnitTest.Logic.PersonClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LifeBoatUnitTest.Logic.Test
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("Dev1")]
        public void AreCollectionsEqualFailsBecauseNoComparerTest()
        {
            //Arrange
            var personManager = new PersonManager();
            var personExpected = new List<Person>();
            var personsActual = new List<Person>();

            personExpected.Add(new Person { FirstName = "Igor1", LastName = "Gomes" });
            personExpected.Add(new Person { FirstName = "Igor2", LastName = "Gomes" });
            personExpected.Add(new Person { FirstName = "Igor3", LastName = "Gomes" });

            //Act
            personsActual = personManager.GetPeople();

            //Assert
            CollectionAssert.AreEqual(personExpected, personsActual);
        }

        [TestMethod]
        [Owner("Dev1")]
        public void AreCollectionsEqualTest()
        {
            //Arrange
            var personManager = new PersonManager();
            var personExpected = new List<Person>();
            var personsActual = new List<Person>();

            //Act
            personExpected.Add(new Person { FirstName = "Igor1", LastName = "Gomes" });
            personExpected.Add(new Person { FirstName = "Igor2", LastName = "Gomes" });
            personExpected.Add(new Person { FirstName = "Igor3", LastName = "Gomes" });

            personsActual = personManager.GetPeople();
            personExpected = personsActual;

            //Assert
            CollectionAssert.AreEqual(personExpected, personsActual);
        }

        [TestMethod]
        [Owner("Dev1")]
        public void AreCollectionsEqualWithComparerTest()
        {
            //Arrange
            var personManager = new PersonManager();
            var personExpected = new List<Person>();
            var personsActual = new List<Person>();

            personExpected.Add(new Person { FirstName = "Igor1", LastName = "Gomes" });
            personExpected.Add(new Person { FirstName = "Igor2", LastName = "Gomes" });
            personExpected.Add(new Person { FirstName = "Igor3", LastName = "Gomes" });

            //Act
            personsActual = personManager.GetPeople();

            //Assert
            //Provider your own "Comparer" to determine equality
            CollectionAssert.AreEqual(personExpected, personsActual,
                Comparer<Person>.Create((x,y) => x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }

        [TestMethod]
        [Owner("Dev1")]
        public void AreCollectionsEquivalentTest()
        {
            //Arrange
            var personManager = new PersonManager();
            var personExpected = new List<Person>();
            var personsActual = new List<Person>();

            //Act
            personsActual = personManager.GetPeople();

            //Add same Person object to new collection, but in different order
            personExpected.Add(personsActual[1]);
            personExpected.Add(personsActual[2]);
            personExpected.Add(personsActual[0]);

            //Assert
            //Checks for the same objects, but in any order
            CollectionAssert.AreEquivalent(personExpected, personsActual);
        }

        [TestMethod]
        [Owner("Dev1")]
        public void IsCollectionOfTypeTest()
        {
            //Arrange
            var personManager = new PersonManager();
            var personsActual = new List<Person>();

            //Act
            personsActual = personManager.GetSupervisors();

            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(personsActual, typeof(Supervisor));
        }
    }
}
