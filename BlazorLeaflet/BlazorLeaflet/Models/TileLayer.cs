namespace BlazorLeaflet.Models
{
    public class TileLayer : GridLayer
    {

        /// <summary>
        /// Instantiates a tile layer object given a URL template.
        /// </summary>
        public string UrlTemplate { get; set; }

        /// <summary>
        /// The minimum zoom level down to which this layer will be displayed (inclusive).
        /// </summary>
        public float MinimumZoom { get; set; }

        /// <summary>
        /// The maximum zoom level up to which this layer will be displayed (inclusive).
        /// </summary>
        public float MaximumZoom { get; set; } = 18;

        /// <summary>
        /// Subdomains of the tile service.
        /// </summary>
        public string[] Subdomains { get; set; } = new string[] { "abc" };

        /// <summary>
        /// URL to the tile image to show in place of the tile that failed to load.
        /// </summary>
        public string ErrorTileUrl { get; set; }

        /// <summary>
        /// If set to true, the zoom number used in tile URLs will be reversed (maxZoom - zoom instead of zoom)
        /// </summary>
        public bool IsZoomReversed { get; set; }

        /// <summary>
        /// The zoom number used in tile URLs will be offset with this value.
        /// </summary>
        public double ZoomOffset { get; set; }

        /// <summary>
        /// If true and user is on a retina display, it will request four tiles of half the specified size and a bigger zoom level in place of one to utilize the high resolution.
        /// </summary>
        public bool DetectRetina { get; set; }

    }
}
