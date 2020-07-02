using System;
namespace BlazorLeaflet.Models
{
    public class WmsLayer : TileLayer
    {
        /// <summary>
        /// The base WMS server URL. Typically ends with a ?.
        /// </summary>
        public string BaseUrl { get; }

        /// <summary>
        /// List of WMS layers to show. Required.
        /// </summary>
        public string[] Layers { get; set; }

        /// <summary>
        /// List of WMS styles to apply. Can be left empty.
        /// </summary>
        public string[] Styles { get; set; }

        /// <summary>
        /// The image format (as a MIME type) to use, such as 'image/png'.
        /// </summary>
        public string ImageFormat { get; set; }

        /// <summary>
        /// Whether the images are transparent. Requires
        /// <see cref="ImageFormat"/> to be 'image/png'.
        /// </summary>
        public bool IsTransparent { get; set; }

        /// <summary>
        /// The WMS version to use, typically '1.1.1' or '1.3.0'.
        /// </summary>
        public string WmsVersion { get; set; }

        /// <summary>
        /// The _c_oordinate _r_eference _s_ystem to use.
        /// </summary>
        public Crs Crs { get; set; }

        /// <summary>
        /// Whether to pass request query parameter keys in upper case.
        /// </summary>
        public bool UseUppercaseParameters { get; set; }

        /// <summary>
        /// Initializes a WMS tile layer pointing to a certain WMS server.
        /// </summary>
        /// <param name="baseUrl">
        /// The base URL for the WMS server to connect to.
        /// </param>
        public WmsLayer(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
    }
}
