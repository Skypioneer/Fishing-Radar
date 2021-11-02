using System.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Index
{
    /// <summary>
    /// Testing the IndexModel class for getting the products list
    /// </summary>
    public class IndexTests
    {
        #region TestSetup

        public static IndexModel pageModel;

        /// <summary>
        /// Initialize a IndexModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(MockLoggerDirect, PageTestsHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Testing OnGet function with REST Get request
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}