using System.IO;

using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// A helper setup class for Unit tests
    /// helps grab necessary data before tests and clean up after tests
    /// </summary>
    [SetUpFixture]
    public class TestFixture
    {
        // Path to the Web Root
        public static string DataWebRootPath = "./wwwroot";

        // Path to the data folder for the content
        public static string DataContentRootPath = "./data/";

        /// <summary>
        /// Before running the unit tests, it deletes old data file folder
        /// Then make a new one for the unit tests
        /// Then copy the original data over to the new folder for preparing unit tests
        /// </summary>
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // Run this code once when the test harness starts up.

            // This will copy over the latest version of the database files

            // C:\repos\5110\ClassBaseline\UnitTests\bin\Debug\net5.0\wwwroot\data
            // C:\repos\5110\ClassBaseline\src\wwwroot\data
            // C:\repos\5110\ClassBaseline\src\bin\Debug\net5.0\wwwroot\data



            // var DataWebPath = "../../../../src/bin/Debug/net5.0/wwwroot/data";
            var DataWebPath = "../../../../src/wwwroot/data";
            var DataUTDirectory = "wwwroot";
            var DataUTPath = DataUTDirectory + "/data";

            // Delete the Detination folder
            if (Directory.Exists(DataUTDirectory))
            {
                Directory.Delete(DataUTDirectory, true);
            }
            
            // Make the directory
            Directory.CreateDirectory(DataUTPath);

            // Copy over all data files
            var filePaths = Directory.GetFiles(DataWebPath);
            foreach (var filename in filePaths)
            {
                string OriginalFilePathName = filename.ToString();
                var newFilePathName = OriginalFilePathName.Replace(DataWebPath, DataUTPath);

                File.Copy(OriginalFilePathName, newFilePathName);
            }
        }

        /// <summary>
        /// clean up after the tests, currently no need because we have copy of the original data and just delete it after use.
        /// </summary>
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}