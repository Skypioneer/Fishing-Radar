using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;


using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Pages.Posts;


using System.Diagnostics;

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



namespace UnitTests.Pages.Posts.MyPosts
{
    public class MyPostsTest
    {

        #region TestSetup
        public static MyPostsModel pageModel;

        /// <summary>
        /// Initialize a MyPostsModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new MyPostsModel(PageTestsHelper.ProductService)
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