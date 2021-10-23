using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Posts.Read
{
    public class Read
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(PageTestsHelper.ProductService)
            {
            };
        }

        #endregion TestSetup
    }
}
