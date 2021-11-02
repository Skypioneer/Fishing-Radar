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
    }
}
