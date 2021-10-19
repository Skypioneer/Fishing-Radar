using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Maker { get; set; }
        
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int[] Ratings { get; set; }

        public string Quantity { get; set; }

        [Range(-1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

 
    }
}