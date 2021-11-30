using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Data representation model class for a product.
    /// </summary>
    public class PostModel : Model
    {
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        //Get/Set product ID
        public string Id { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        //Get/set the maker of said product
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        //Get/Set image for a product
        public string Image { get; set; }

        [Url]
        //Get/set URL for a product
        public string Url { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        //Get/set Title of a product
        public string Title { get; set; }

        [StringLength(maximumLength: 1000, MinimumLength = 1, ErrorMessage = "The Description should have a length of more than {2} and less than {1}")]
        //Get/set Description for a product
        public string Description { get; set; }

        [RegularExpression("0-9")]
        // Get/set list of ratings for a producrt
        public int[] Ratings { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The Setup should have a length of more than {2} and less than {1}")]
        //Get/set the setup used for catching the fish
        public string Setup { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        //Get/set the date when the fish was caught
        public string Date { get; set; }

        [Range(14.0, 95.0)]
        //Get/set the water temperature when the fish was caught
        public int WaterTemp { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The Location should have a length of more than {2} and less than {1}")]
        //Get/set the location when the fish was caught
        public string Location { get; set; }

        // Store the Comments entered by the users on this product
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        /// <summary>
        /// Retrieve the filename for the fishing spot JSON data file.
        /// </summary>
        /// <returns>File name</returns> 
        public string GetFileName() => "products.json";

        // Get/set ToString method to get a string representation
        public override string ToString() => JsonSerializer.Serialize<PostModel>(this);

    }
}