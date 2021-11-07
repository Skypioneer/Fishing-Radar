using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Testing the CreateModel class for the create function of CRUDI.
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        public static CreateModel pageModel;

        /// <summary>
        /// Initialize a UpdateModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(PageTestsHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// OnGet method test to ensure that the Product attribute in CreateModel is 
        /// set to a new ProductModel instance by checking whether its null.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Set_Product_Attribute()
        {
            // Arrange

            // Act

            // OnGet sets the Product attribute, so it should not be null at this point
            pageModel.OnGet();
            var result = pageModel.Product;

            // Assert
            Assert.AreEqual(false, result == null);
        }
        #endregion OnGet

        #region OnPost
        /// <summary>
        /// Testing OnPost function with an Invalid Product ID
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
        /// OnPost test method: tests if newly created product is saved to the 
        /// JSON file after calling OnPost
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Save_Created_Data_To_Json()
        {
            // Arrange
            pageModel.OnGet();
            var data = pageModel.Product;

            // Act
            pageModel.OnPost();
            var result = PageTestsHelper.ProductService.GetAllData().First(x => x.Id == data.Id);

            // Assert
            Assert.AreEqual(data.Id, result.Id);
        }
        #endregion OnPost
    }
}