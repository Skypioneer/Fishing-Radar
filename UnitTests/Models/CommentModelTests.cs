using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    class CommentModelTests
    {
        #region TestSetup
        // comment model instance to test on
        public static CommentModel commentModel;

        /// <summary>
        /// Initialize the comment model for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            //PageTestsHelper.ProductService.GetAllData().First();
            commentModel = PageTestsHelper.ProductService.GetAllData().First().CommentList[0];
        }
        #endregion TestSetup

        /// <summary>
        /// ToString should return a serialized Json string. Checks if the comment model
        /// instance's ToString matches the test data for each field
        /// </summary>
        [Test]
        public void ToString_Valid_Should_Return_Serialized_Json_String()
        {
            // Arrange
            var data = new CommentModel();
            {
                data.Id = commentModel.Id;
                data.Comment = commentModel.Comment;
            }

            // Act
            var result = data.ToString();

            // Assert
            Assert.AreEqual(commentModel.ToString(), result);
        }
    }
}