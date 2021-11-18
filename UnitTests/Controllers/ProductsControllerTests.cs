using ContosoCrafts.WebSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Controllers
{
    /// <summary>
    /// Unit test class for ProductsController.cs
    /// </summary>
    class ProductsControllerTests
    {
        #region TestSetup
        // The ProductsController instance to test on
        public static ProductsController productsController;

        /// <summary>
        /// Initialize the ProductsController for testing
        /// </summary>
        [SetUp]
        public void TestInitiailize()
        {
            productsController = new ProductsController(PageTestsHelper.ProductService);
        }
        #endregion TestSetup

        /// <summary>
        /// Get request should return a list of products. Ensures the model state of the ProductsController
        /// is valid and that there are elements present in the returned list.
        /// </summary>
        [Test]
        public void Get_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            var result = productsController.Get();

            // Assert
            Assert.AreEqual(true, productsController.ModelState.IsValid);
            Assert.AreEqual(true, result.ToList().Any());
        }

        /// <summary>
        /// Patch request should return an Ok result. Ensures the returned OkResult is a valid 
        /// OkResult instance by verifying against another OkResult's ToString and StatusCode.
        /// </summary>
        [Test]
        public void Patch_Valid_Should_Return_Ok_Result()
        {
            // Arrange
            var data = new ProductsController.RatingRequest
            {
                ProductId = "Shark",
                Rating = 5
            };

            // Act
            var result = productsController.Patch(data) as OkResult;

            // Assert
            Assert.AreEqual(new OkResult().ToString(), result.ToString());
            Assert.AreEqual(new OkResult().StatusCode, result.StatusCode);
        }
    }
}