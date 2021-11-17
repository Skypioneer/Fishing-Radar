using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.Posts;

namespace UnitTests.Pages.Posts.Update
{
    /// <summary>
    /// Testing the Update Model class for the update function of CRUDI.
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        /// <summary>
        /// Initialize a UpdateModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(PageTestsHelper.ProductService)
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
            pageModel.OnGet("Lake Trout");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Lake Trout from Green Lake", pageModel.Product.Title);
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

        /// <summary>
        /// Testing OnPost function with a valid input of a new product info
        /// The model state should then be valid and the Page should be returned to index page
        /// </summary>
        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new PostModel
            {
                Id = "selinazawacki-moon",
                Title = "title",
                Description = "description",
                Url = "url",
                Image = "image",
                Setup = "spinner",
                Date = "2001/09/01",
                WaterTemp = 70,
                Location = "GreenLake"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        /// <summary>
        /// Testing OnPost function with a Invalid Product ID
        /// The model state should then be invalid
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}