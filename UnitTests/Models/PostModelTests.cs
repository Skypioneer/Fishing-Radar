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
    /// Unit test class for PostModel.cs.
    /// </summary>
    class PostModelTests
    {
        #region TestSetup
        // PostModel instance to test on
        public static PostModel postModel;

        /// <summary>
        /// Initialize the PostModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            postModel = PageTestsHelper.ProductService.GetAllData().First();
            
        }
        #endregion TestSetup

        /// <summary>
        /// ToString should return a serialized Json string. Checks if the PostModel
        /// instance's ToString matches the test data instance's ToStrin after manually
        /// setting each field.
        /// </summary>
        [Test]
        public void ToString_Valid_Should_Return_Serialized_Json_String()
        {
            // Arrange
            var data = new PostModel();
            {
                data.Id = postModel.Id;
                data.Maker = postModel.Maker;
                data.Image = postModel.Image;
                data.Url = postModel.Url;
                data.Title = postModel.Title;
                data.Description = postModel.Description;
                data.Ratings = postModel.Ratings;
                data.Setup = postModel.Setup;
                data.Date = postModel.Date;
                data.WaterTemp = postModel.WaterTemp;
                data.Location = postModel.Location;
                data.CommentList = postModel.CommentList;
            }

            // Act
            var result = data.ToString();

            // Assert
            Assert.AreEqual(postModel.ToString(), result);
        }
    }
}
