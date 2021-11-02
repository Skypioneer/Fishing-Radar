using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;


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
        /// Testing OnGet function with a valid Product ID
        /// The model state should then be valid and the title should be matched accordingly
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = PageTestsHelper.ProductService.GetAllData().Count();

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, PageTestsHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet
    }
}