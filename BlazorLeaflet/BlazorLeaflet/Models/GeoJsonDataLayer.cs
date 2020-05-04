using BlazorLeaflet.Utils;

namespace BlazorLeaflet.Models
{
    public class GeoJsonDataLayer : InteractiveLayer, ICanUpdateStyleLayer
    {
        public string GeoJsonData { get; set; }
    }
}
