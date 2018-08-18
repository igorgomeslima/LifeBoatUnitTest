using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeBoatUnitTest.Logic.Test
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange
            var fileProcess = new FileProcess();
            bool resultMethodFileExists;

            //Act
            resultMethodFileExists = fileProcess.FileExists(@"C:\Windows\notepad.exe");

            //Assert
            Assert.IsTrue(resultMethodFileExists);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            //Arrange
            var fileProcess = new FileProcess();
            bool resultMethodFileExists;

            //Act
            resultMethodFileExists = fileProcess.FileExists(@"C:\:(.exe");

            //Assert
            Assert.IsFalse(resultMethodFileExists);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            //Arrange
            var fileProcess = new FileProcess();

            //Act
            fileProcess.FileExists(string.Empty);
        }

        [TestMethod]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            //Arrange
            var fileProcess = new FileProcess();

            try
            {
                //Act
                fileProcess.FileExists(string.Empty);
            }
            catch (Exception)
            {
                //Success
                return;
            }

            //Assert
            Assert.Fail("FileExists method did NOT throw an ArgumentNullException.");
        }
    }
}
