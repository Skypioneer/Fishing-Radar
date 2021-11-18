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

        /// <summary>
        /// ToString should return a serialized Json string. Checks if the FishingSpotModel
        /// instance's ToString matches the test data instance's ToString after manually
        /// setting each field.
        /// </summary>
        [Test]
        public void ToString_Valid_Should_Return_Serialized_Json_String()
        {
            // Arrange
            var data = new FishingSpotModel();
            {
                data.Id = fishingSpotModel.Id;
                data.SpotName = fishingSpotModel.SpotName;
                data.City = fishingSpotModel.City;
                data.Url = fishingSpotModel.Url;
            }

            // Act
            var result = data.ToString();

            // Assert
            Assert.AreEqual(fishingSpotModel.ToString(), result);
        }
    }
}