﻿using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// Testing the DeleteModel class for the delete function of CRUDI.
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup
        public static DeleteModel pageModel;

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(PageTestsHelper.ProductService)
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
        #endregion OnGet

        #region OnGet Invalid

        /// <summary>
        /// OnGet test method
        /// Ppassing an invalid ID should redirect page to the index page
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

        #endregion

        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange

            // First Create the product to delete
            pageModel.Product = new CreateModel(PageTestsHelper.ProductService).CreateData();
            pageModel.Product.Title = "Example to Delete";
            PageTestsHelper.ProductService.CreateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, PageTestsHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }

        /// <summary>
        /// Testing OnPost function with a valid input of a new product info
        /// The model state should then be valid and the Page should be returned to index page
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