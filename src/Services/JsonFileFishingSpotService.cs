using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// JSON file processing class for the fishing spot data JSON file.
    /// </summary>
    public class JsonFileFishingSpotService
    {
        /// <summary>
        /// Constructor initializes the web host environment.
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileFishingSpotService(IWebHostEnvironment webHostEnvironment)
        {
           WebHostEnvironment = webHostEnvironment;
        }

        // Helper for building file path
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Builds JSON file path
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "fishingSpot.json"); }
        }

        /// <summary>
        /// Retrieve all data from the fishing spot JSON database and returns it as an enumerable.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FishingSpotModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<FishingSpotModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}