using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    class FishingGuideModelTests
    {
        #region TestSetup
        // FishingGuideModel instance to test on
        public static FishingGuideModel fishingGuideModel;

        /// <summary>
        /// Initialize the FishingGuideModel for testing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            fishingGuideModel = PageTestsHelper.FishingGuideService.GetAllData().First();

        }
        #endregion TestSetup

        /// <summary>
        /// ToString should return a serialized Json string. Checks if the FishingGuideModel
        /// instance's ToString matches the test data instance's ToString after manually
        /// setting each field.
        /// </summary>
        [Test]
        public void ToString_Valid_Should_Return_Serialized_Json_String()
        {
            // Arrange
            var data = new FishingGuideModel();
            {
                data.Id = fishingGuideModel.Id;
                data.Name = fishingGuideModel.Name;
                data.PhoneNumber = fishingGuideModel.PhoneNumber;
                data.FishingTarget = fishingGuideModel.FishingTarget;
                data.Price = fishingGuideModel.Price;
            }

            // Act
            var result = data.ToString();

            // Assert
            Assert.AreEqual(fishingGuideModel.ToString(), result);
        }
    }
}
