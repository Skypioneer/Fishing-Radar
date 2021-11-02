using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    /// <summary>
    /// Unit test class for ProductModel.cs.
    /// </summary>
    class ProductModelTests
    {
        #region TestSetup
        // ProductModel instance to test on
        public static ProductModel productModel;

        /// <summary>
        /// Initialize the ProductModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            productModel = PageTestsHelper.ProductService.GetAllData().First();
            
        }
        #endregion TestSetup

        /// <summary>
        /// ToString should return a serialized Json string. Checks if the ProductModel
        /// instance's ToString matches the test data instance's ToStrin after manually
        /// setting each field.
        /// </summary>
        [Test]
        public void ToString_Valid_Should_Return_Serialized_Json_String()
        {
            // Arrange
            var data = new ProductModel();
            {
                data.Id = productModel.Id;
                data.Maker = productModel.Maker;
                data.Image = productModel.Image;
                data.Url = productModel.Url;
                data.Title = productModel.Title;
                data.Description = productModel.Description;
                data.Ratings = productModel.Ratings;
                data.Quantity = productModel.Quantity;
                data.Price = productModel.Price;
            }

            // Act
            var result = data.ToString();

            // Assert
            Assert.AreEqual(productModel.ToString(), result);
        }
    }
}
