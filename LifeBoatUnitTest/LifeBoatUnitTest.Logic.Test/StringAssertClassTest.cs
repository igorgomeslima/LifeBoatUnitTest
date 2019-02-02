using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace LifeBoatUnitTest.Logic.Test
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("Dev1")]
        public void ContainsTest()
        {
            //Arrange
            string str1 = "John Wick";
            string str2 = "Wick";

            //Assert
            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("Dev1")]
        public void StartWithTest()
        {
            //Arrange
            string str1 = "All Lower Case";
            string str2 = "All Lower";

            //Assert
            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("Dev1")]
        public void IsAllLowerCaseTest()
        {
            //Arrange
            var regex = new Regex(@"^([^A-Z])+$");
            string str1 = "all lower case";

            //Assert
            StringAssert.Matches(str1, regex);
        }

        [TestMethod]
        [Owner("Dev1")]
        public void IsNotAllLowerCaseTest()
        {
            //Arrange
            var regex = new Regex(@"^([^A-Z])+$");
            string str1 = "ALL LOWER CASE";

            //Assert
            StringAssert.DoesNotMatch(str1, regex);
        }
    }
}
