using System.Text.Json.Serialization;

namespace Ride.Models.ClientModels
{
    public class FareInputRequest
    {
        [JsonPropertyName("pickupLocation")]
        public string PickupLocation { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }
    }
}
