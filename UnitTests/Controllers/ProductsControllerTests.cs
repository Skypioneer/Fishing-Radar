using ContosoCrafts.WebSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Controllers
{
    /// <summary>
    /// Unit test class for ProductsController.cs
    /// </summary>
    class ProductsControllerTests
    {
        #region TestSetup
        public static ProductsController productsController;

        [SetUp]
        public void TestInitiailize()
        {
            productsController = new ProductsController(PageTestsHelper.ProductService);
        }
        #endregion TestSetup

    }
}
