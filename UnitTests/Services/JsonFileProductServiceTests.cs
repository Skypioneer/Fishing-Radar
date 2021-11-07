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
        /// AddRating test method
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
        /// AddRating test method
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

        /// <summary>
        /// UpdateData test method
        /// Tests if when a nonexistent data is called to have its data updated, UpdateData
        /// returns null since data doesn't exist in the JSON file.
        /// </summary>
        [Test]
        public void UpdateData_Invalid_Data_Does_Not_Exist_Should_Return_Null()
        {
            // Arrange
            var data = new ProductModel()
            {
                Id = "Id that doesn't exist"
            };

            // Act
            var result = PageTestsHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// UpdateData test method
        /// Tests if the data returned from UpdateData matches the updates we made.
        /// </summary>
        [Test]
        public void UpdateData_Valid_Data_Exists_Should_Return_Updated_Data()
        {
            // Arrange
            var data = PageTestsHelper.ProductService.GetAllData().First(x => x.Id == "fly fishing");

            // Change all attributes that can be updated in UpdateData
            data.Title = "new title";
            data.Description = "new description";
            data.Url = "new URL";
            data.Image = "new image";
            data.Quantity = "5";
            data.Price = 5;

            // Act
            var result = PageTestsHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual(data.ToString(), result.ToString());
        }

    }
}
