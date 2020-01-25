using System.Drawing;

namespace BlazorLeaflet.Models
{
    public class MapArgs
    {
        /// <summary>
        /// Coordinate Reference System to use. Don't change this if you're not sure what it means. By default it is EPSG3857
        /// </summary>
        public string CRS { get; set; }
        
        /// <summary>
        /// Initial geographical center of the map.
        /// </summary>
        public PointF Center { get; set; }
        
        /// <summary>
        /// Initial map zoom.
        /// </summary>
        public float? Zoom { get; set; }
        
        /// <summary>
        /// Minimum zoom level of the map. Overrides any minZoom set on map layers.
        /// </summary>
        public float? MinZoom { get; set; }
        
        /// <summary>
        /// Maximum zoom level of the map. This overrides any maxZoom set on map layers.
        /// </summary>
        public float? MaxZoom { get; set; }
    }
}