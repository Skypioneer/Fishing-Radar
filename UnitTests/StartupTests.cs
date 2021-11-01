using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

using NUnit.Framework;

namespace UnitTests.Pages.Startup
{
    /// <summary>
    /// A test class for the Startup class
    /// </summary>
    public class StartupTests
    {
        #region TestSetup

        //initialization for the tests
        [SetUp]
        public void TestInitialize()
        {
        }

        /// <summary>
        /// creating a inside class with the base configuration of the exmaple web startup class
        /// </summary>
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        #region ConfigureServices
        /// <summary>
        /// test startup build function with valid default configuration
        /// the webhost should be not null after build
        /// </summary>
        [Test]
        public void Startup_ConfigureServices_Valid_Default_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices
    }
}