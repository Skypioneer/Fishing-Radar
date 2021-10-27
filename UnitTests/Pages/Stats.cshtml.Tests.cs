using NUnit.Framework;


using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Pages
{
    class StatsTests
    {

        #region TestSetup
        public static StatsModel pageModel;

        /// <summary>
        /// Initialize a Stats model for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            //Empty constructor for stats model
            pageModel = new StatsModel()
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Request_Should_Return_True()
        {
            // Arrange

            // Act
            pageModel.OnGet();
            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnGet

    }
}
