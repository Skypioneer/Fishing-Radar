using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Fishing spot model class to represent fishing spot data.
    /// </summary>
    public class FishingSpotModel : Model
    {
        // Get/Set for the fishing spot ID
        public string Id { get; set; }

        [Required]
        [StringLength(maximumLength: 85, MinimumLength = 1, ErrorMessage = "The Fishing Spot Name field must be between {2} and {1} characters long.")]
        // Get/Set for the name of the fishing spot
        public string SpotName { get; set; }

        [Required]
        [StringLength(maximumLength: 85, MinimumLength = 1, ErrorMessage = "The City field must be between {2} and {1} characters long.")]
        // Get/Set for the city in which the fishing spot is located
        public string City { get; set; }

        [Required]
        [Url]
        // Get/Set for a URL link to a website with information about the fishing spot
        public string Url { get; set; }

        // Get/set ToString method to get a string representation
        public override string ToString() => JsonSerializer.Serialize<FishingSpotModel>(this);

        /// <summary>
        /// Retrieve the filename for the fishing spot JSON data file.
        /// </summary>
        /// <returns>File name</returns>        
        public string GetFileName() => "fishingSpot.json";
    }
}