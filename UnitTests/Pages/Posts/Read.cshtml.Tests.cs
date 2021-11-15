using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Posts.Read
{
    public class Read
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(PageTestsHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// OnGet test method
        /// Product attribute should be initialized when Get request is made which is verified
        /// by checking the title of the first product.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("Shark");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("How to handle shark if you catch them", pageModel.Product.Title);
        }

        /// <summary>
        /// OnGet test method
        /// Ppassing an invalid ID should redirect Read page to the index page
        /// so that the website doesn't crash
        /// </summary>
        [Test]
        public void OnGet_Invalid_Should_Redirect_To_Index_Page()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("ID that doesn't exist") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);
        }
        #endregion OnGet
    }
}
