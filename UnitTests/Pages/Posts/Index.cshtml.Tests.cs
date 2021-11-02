using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Posts;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// Testing the IndexModel class for the index function of CRUDI
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        public static PageContext pageContext;

        public static IndexModel pageModel;

        /// <summary>
        /// Initialize a IndexModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(PageTestsHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Testing OnGet function with a valid Product ID
        /// The model state should then be valid and the title should be matched accordingly
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