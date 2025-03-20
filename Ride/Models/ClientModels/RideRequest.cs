using System.Text.Json.Serialization;

namespace Ride.Models.ClientModels
{
    public class RideRequest
    {
        [JsonPropertyName("fareId")]
        public int FareId { get; set; }
      
    }
}
