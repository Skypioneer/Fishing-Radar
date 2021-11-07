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

        /// <summary>
        /// Tests if when a rating is added to a product with a null Ratings array, that 
        /// product will create a new Ratings array and add the rating.
        /// </summary>
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

        /// <summary>
        /// Tests if when a rating is added to a post, the rating is added to the Ratings
        /// array, meaning it should be the last element in the array.
        /// </summary>
        [Test]
        public void AddRating_Valid_Rating_Should_Be_Added_To_Ratings_Array()
        {
            // Arrange
            var data = PageTestsHelper.ProductService.GetAllData().First(x => x.Id == "Lake Trout");

            // Act
            PageTestsHelper.ProductService.AddRating(data.Id, 3);
            var result = PageTestsHelper.ProductService.GetAllData().First(x => x.Id == data.Id);

            // Assert
            Assert.AreEqual(3, result.Ratings[result.Ratings.Length - 1]);
        }

    }
}
