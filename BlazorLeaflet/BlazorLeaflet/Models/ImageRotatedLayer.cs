using System.Drawing;

namespace BlazorLeaflet.Models
{
	public class ImageRotatedLayer : ImageLayer
	{
		public PointF Corner3 { get; }

		public ImageRotatedLayer(string url, PointF topLeftCorner, PointF topRightCorner, PointF bottomLeftCorner)
			: base(url, topLeftCorner, topRightCorner)
		{
			this.Corner3 = bottomLeftCorner;
		}
	}
}