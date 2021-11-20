using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{   
    /// <summary>
    /// Map Page that will show an embedded map of fishing locations.
    /// </summary>
    public class MapModel : PageModel
    {
        /// <summary>
        /// Initializes the fishing spot service attribute.
        /// </summary>
        /// <param name="fishingSpotService"></param>
        public MapModel(JsonFileProductService<FishingSpotModel> fishingSpotService)
        {
            FishingSpotService = fishingSpotService;
        }

        // JSON file processing helper
        public JsonFileProductService<FishingSpotModel> FishingSpotService { get; }

        // Enumerable list of fishing spots from the JSON database
        public IEnumerable<FishingSpotModel> FishingSpots { get; private set; }

        /// <summary>
        /// REST Get request
        /// Retrieve all the fishing spots to be displayed on the web page.
        /// </summary>
        public void OnGet()
        {
            FishingSpots = FishingSpotService.GetAllData();
        }
    }
}