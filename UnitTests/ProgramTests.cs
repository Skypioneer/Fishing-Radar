using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ContosoCrafts.WebSite;

namespace UnitTests
{
    /// <summary>
    /// unit test class for program class
    /// </summary>
    class ProgramTests
    {
        #region TestSetup

        //initialization for the tests
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region ConfigureServices
        /// <summary>
        /// test startup build function with valid default configuration
        /// the webhost should be not null after build
        /// </summary>
        [Test]
        public void Program_CreateHostBuilder_Valid_Default_Should_Pass()
        {
            string[] config = new string[0];
            //action
            var webHost = Program.CreateHostBuilder(config);

            Assert.IsNotNull(webHost);

        }
        #endregion ConfigureServices
    }
}