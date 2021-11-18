﻿using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
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
using ContosoCrafts.WebSite.Pages.Posts;

namespace UnitTests.Pages
{
    /// <summary>
    /// Testing the AboutModel class for setting logger function
    /// </summary>
    public class AboutTest
    {

        #region TestSetup
        public static AboutModel pageModel;

        /// <summary>
        /// Initialize a AboutModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<AboutModel>>();

            pageModel = new AboutModel(MockLoggerDirect)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Testing OnGet function with REST Get request
        /// The model state should then be valid 
        /// </summary>
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