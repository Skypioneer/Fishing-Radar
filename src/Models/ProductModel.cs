using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Data representation model class for a product.
    /// </summary>
    public class ProductModel
    {
        //Get/Set product ID
        public string Id { get; set; }
        //Get/set the maker of said product
        public string Maker { get; set; }
        
        [JsonPropertyName("img")]
        //Get/Set image for a product
        public string Image { get; set; }
        //Get/set URL for a product
        public string Url { get; set; }
        //Get/set Title of a product
        public string Title { get; set; }
        //Get/set Description for a product
        public string Description { get; set; }
        // Get/set list of ratings for a producrt
        public int[] Ratings { get; set; }

        //Get/set Get the quantity field from a product
        public string Quantity { get; set; }

        [Range(-1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]

        //Get/set Price of a product
        public int Price { get; set; }

        // Get/set ToString method to get a string representation
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

 
    }
}