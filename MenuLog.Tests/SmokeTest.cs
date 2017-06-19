using MenuLog.Core.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuLog.Tests
{
    [TestClass]
    public class SmokeTest : BaseFixtureWithStartup
    {
        [TestMethod]
        public void CanInitialize()
        {
            Assert.IsNotNull(IoC.Container); //Tests are initialized with the BaseFixtureWithStartup
        }
    }
}
