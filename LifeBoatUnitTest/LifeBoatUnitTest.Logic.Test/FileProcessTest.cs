using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeBoatUnitTest.Logic.Test
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\:(.exe";
        private string _GoodFileName;

        #region Class Initialize and Cleanup

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            testContext.WriteLine("In the Class Initialize method.");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
           
        }

        #endregion

        #region Tests Initialize and Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName == nameof(FileNameDoesExist))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating the file {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, default(string));
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == nameof(FileNameDoesExist))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting the file {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FileNameDoesExist()
        {
            //Arrange
            var fileProcess = new FileProcess();
            bool resultMethodFileExists;

            //TestContext.WriteLine($"Creating the file {_GoodFileName}");
            //File.AppendAllText(_GoodFileName, default(string));

            //Act
            TestContext.WriteLine($"Testing the file {_GoodFileName}");
            resultMethodFileExists = fileProcess.FileExists(_GoodFileName);
            //resultMethodFileExists = fileProcess.FileExists(@"C:\Windows\notepad.exe");

            //TestContext.WriteLine($"Deleting the file {_GoodFileName}");
            //File.Delete(_GoodFileName);

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
            resultMethodFileExists = fileProcess.FileExists(BAD_FILE_NAME);

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

        private void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
    }
}
