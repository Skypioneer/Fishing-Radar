using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Fishing spot model class to represent fishing spot data.
    /// </summary>
    public class FishingSpotModel
    {
        // Get/Set for the fishing spot ID
        public string Id { get; set; }

        // Get/Set for the name of the fishing spot
        public string SpotName { get; set; }

        // Get/Set for the city in which the fishing spot is located
        public string City { get; set; }

        // Get/Set for a URL link to a website with information about the fishing spot
        public string Url { get; set; }
    }
}
