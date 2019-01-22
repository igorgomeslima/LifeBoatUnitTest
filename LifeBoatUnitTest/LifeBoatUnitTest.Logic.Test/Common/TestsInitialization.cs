using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeBoatUnitTest.Logic.Test.Common
{
    /// <summary>
    /// Assembly Initialize and Clean up methods
    /// </summary>
    [TestClass]
    public class TestsInitialization
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            testContext.WriteLine("In the Assembly Initialize method.");
            //TODO: Create resources needed for tests.
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //TODO: Clean up any resources used by tests.
        }
    }
}
