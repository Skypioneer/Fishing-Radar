using System.Text.Json;

namespace ContosoCrafts.WebSite.Models
{
    public class FishingGuideModel
    {
        // Get/Set for the fishing Guide ID
        public string Id { get; set; }

        // Get/Set for the name of the fishing guide
        public string Name { get; set; }

        // Get/Set for the phone number of the fishing guide
        public string PhoneNumber { get; set; }

        // Get/Set fishing guide's targetted fish
        public string FishingTarget { get; set; }

        // Get/Set fishing guide's price
        public string Price { get; set; }

        // Get/set ToString method to get a string representation
        public override string ToString() => JsonSerializer.Serialize<FishingGuideModel>(this);
    }
}