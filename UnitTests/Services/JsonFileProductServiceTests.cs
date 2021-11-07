using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Services
{
    /// <summary>
    /// Unit Test class for JsonFileProductService.cs
    /// </summary>
    class JsonFileProductServiceTests
    {
        #region TestSetup

        /// <summary>
        /// Default constructor to initialize tests.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        public void AddRating_Valid_Null_Ratings_Should_Initialize_Ratings_Array()
        {
            // Arrange
            var data = new ProductModel()
            {
                Id = "new ID"
            };
            PageTestsHelper.ProductService.CreateData(data);

            // Act
            PageTestsHelper.ProductService.AddRating(data.Id, 5);
            var result = PageTestsHelper.ProductService.GetAllData().First(x => x.Id == data.Id);

            // Assert
            Assert.AreEqual(new int[] { 5 }, result.Ratings);
        }

    }
}
