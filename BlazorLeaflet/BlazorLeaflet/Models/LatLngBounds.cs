using System.Text.Json.Serialization;

namespace BlazorLeaflet.Models
{
    public class LatLngBounds
    {
        [JsonPropertyName("_northEast")]
        public LatLng NorthEast { get; set; }
        [JsonPropertyName("_southWest")]
        public LatLng SouthWest { get; set; }
    }
}
