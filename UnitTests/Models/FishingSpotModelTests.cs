using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    class FishingSpotModelTests
    {
        #region TestSetup
        // FishingSpotModel instance to test on
        public static FishingSpotModel fishingSpotModel;

        /// <summary>
        /// Initialize the FishingSpotModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            fishingSpotModel = PageTestsHelper.FishingSpotService.GetAllData().First();

        }
        #endregion TestSetup
    }
}
