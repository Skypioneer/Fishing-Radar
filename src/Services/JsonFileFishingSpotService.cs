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
    }
}
