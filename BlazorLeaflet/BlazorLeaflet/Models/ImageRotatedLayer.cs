using System.Drawing;

namespace BlazorLeaflet.Models
{
	public class ImageRotatedLayer : ImageLayer
	{
		public PointF Corner3 { get; }

		public ImageRotatedLayer(string url, PointF corner1, PointF corner2, PointF corner3)
			: base(url, corner1, corner2)
		{
			Corner3 = corner3;
		}
	}
}