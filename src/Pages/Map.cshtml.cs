using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{   
    /// <summary>
    /// Map Page that will show an embedded map of fishing locations.
    /// </summary>
    public class MapModel : PageModel
    {
        // JSON file processing helper
        public JsonFileProductService<FishingSpotModel> FishingSpotService { get; }

        /// <summary>
        /// Initializes the fishing spot service attribute.
        /// </summary>
        /// <param name="fishingSpotService"></param>
        public MapModel(JsonFileProductService<FishingSpotModel> fishingSpotService)
        {
            FishingSpotService = fishingSpotService;
        }

        // Fishing spot object for data creation
        [BindProperty]
        public FishingSpotModel FishingSpot { get; set; }

        // Enumerable list of fishing spots from the JSON database
        public IEnumerable<FishingSpotModel> FishingSpotList { get; private set; }

        /// <summary>
        /// REST Get request
        /// Retrieve all the fishing spots to be displayed on the web page and creates
        /// a default FishingSpot instance.
        /// </summary>
        public void OnGet()
        {
            FishingSpotList = FishingSpotService.GetAllData();
            FishingSpot = CreateData();
        }

        /// <summary>
        /// REST post request
        /// Save the newly created data to the JSON dataset via the FishingSpotService.
        /// </summary>
        /// <returns>Redirection to the same page</returns>
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            // Create and save the data to the JSON dataset
            FishingSpotService.CreateData(FishingSpot);

            // After saving data, redirect to same page to reload the locations list
            return RedirectToPage();
        }

        /// <summary>
        /// Creates a new FishingSpotModel that can be added to the database.
        /// </summary>
        /// <returns>FishingSpotModel instance with default values</returns>
        private FishingSpotModel CreateData()
        {
            return new FishingSpotModel()
            {
                Id = System.Guid.NewGuid().ToString()
            };
        }
    }
}