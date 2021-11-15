using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Model class for fishing guide page
    /// </summary>
    public class GuideModel : PageModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fishingGuideService"></param>
        public GuideModel(JsonFileFishingGuideService fishingGuideService)
        {
            FishingGuideService = fishingGuideService;
        }

        // Helper field for performing actions on and getting the products list
        public JsonFileFishingGuideService FishingGuideService { get; }
        // List of all guides
        public IEnumerable<FishingGuideModel> Guides { get; private set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
            Guides = FishingGuideService.GetAllData();
        }
    }
}