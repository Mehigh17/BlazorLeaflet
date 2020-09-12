namespace BlazorLeaflet.Models
{
	/// <summary>
	/// Shapefile layer - Requires Leaflet.Shapefile plugin
	/// </summary>
	public class ShapefileLayer : Layer
	{
		/// <summary>
		/// Instantiates a tile layer object given a URL template.
		/// </summary>
		public string UrlTemplate { get; set; }
	}
}
