using NUnit.Framework;
using System.Linq;
using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages
{
    /// <summary>
    /// Unit test class for Guide.cshtml.cs
    /// </summary>
    public class GuideTest
    {
        #region TestSetup
        public static GuideModel pageModel;

        /// <summary>
        /// Initialize GuideModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new GuideModel(PageTestsHelper.FishingGuideService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// OnGet test for REST Get request
        /// Checks if the model state is valid and if fishing guide model is initialized
        /// to the list of fishing guides, retrieved from the JSON database.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Request_Should_Return_Fishing_Guides()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Guides.ToList().Any());
        }

        #endregion OnGet

    }
}