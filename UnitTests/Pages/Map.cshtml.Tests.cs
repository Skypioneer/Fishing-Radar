using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.Posts;

using System.Linq;

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

using Moq;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Pages
{
    /// <summary>
    /// Unit test class for Map.cshtml.cs
    /// </summary>
    public class MapTest
    {
        #region TestSetup
        public static MapModel pageModel;

        /// <summary>
        /// Initialize MapModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new MapModel(PageTestsHelper.FishingSpotService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// OnGet test for REST Get request
        /// Checks if the model state is valid and if FishingSpots is initialized
        /// to the list of fishing spots, retrieved from the JSON database.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Request_Should_Return_Fishing_Spots()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.FishingSpotList.ToList().Any());
        }

        #endregion OnGet

    }
}