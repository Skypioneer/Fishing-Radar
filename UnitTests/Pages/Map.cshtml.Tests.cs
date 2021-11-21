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
        public void OnGet_Valid_Request_Should_Return_Fishing_Spot_List()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.FishingSpotList.ToList().Any());
        }

        /// <summary>
        /// OnGet test for REST Get request
        /// Checks if the model state is valid and if FishingSpot is initialized
        /// to a non-null state.
        /// </summary>
        [Test]
        public void OnGet_Valid_Request_Should_Return_Fishing_Spot()
        {
            // Arrange

            // Act
            pageModel.OnGet();
            var result = pageModel.FishingSpot;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(false, result == null);
        }

        #endregion OnGet

        #region OnPost


        /// <summary>
        /// Testing OnPost function with an Invalid FishingSpot ID
        /// The model state should then be invalid
        /// </summary>
        [Test]
        public void OnPost_Invalid_Page_Not_Valid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        /// <summary>
        /// OnPost test method: tests if newly created fishing spot is saved to the 
        /// JSON file after calling OnPost
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Save_Created_Data_To_Json()
        {
            // Arrange
            pageModel.OnGet();
            var data = pageModel.FishingSpot;

            // Act
            pageModel.OnPost();
            var result = PageTestsHelper.FishingSpotService.GetAllData().First(x => x.Id == data.Id);

            // Assert
            Assert.AreEqual(data.Id, result.Id);
        }

        #endregion OnPost

    }
}