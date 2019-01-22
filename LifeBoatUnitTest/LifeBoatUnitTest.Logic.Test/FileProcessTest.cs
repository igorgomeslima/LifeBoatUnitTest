using System;
using System.Configuration;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeBoatUnitTest.Logic.Test
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\:(.exe";
        private const string FILE_NAME = @"FileToDeploy.txt";

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
        [Description("Check to see if a file does exist.")]
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
        [Timeout(3000)]
        public void SimulateTimeout()
        {
           Thread.Sleep(5000);
        }
        
        [TestMethod]
        [Description("Check to see if a file does NOT exist.")]
        [Owner("Dev1")]
        [Priority(0)]
        [TestCategory("NoException")]
        [Ignore("")]
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
        [Owner("Dev1")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            //Arrange
            var fileProcess = new FileProcess();
            string fileName;
            bool resultMethodFileExists;

            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";

            //Act
            TestContext.WriteLine($"Checking file: {fileName}");
            resultMethodFileExists = fileProcess.FileExists(fileName);

            //Assert
            Assert.IsTrue(resultMethodFileExists);
        }

        [TestMethod]
        [Owner("Dev1")]
        [Priority(0)]
        [TestCategory("NoException")]
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
        [Owner("Dev2")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            //Arrange
            var fileProcess = new FileProcess();

            //Act
            fileProcess.FileExists(string.Empty);
        }

        [TestMethod]
        [Owner("Dev3")]
        [Priority(1)]
        [TestCategory("Exception")]
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
