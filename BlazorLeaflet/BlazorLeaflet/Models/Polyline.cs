using System.Drawing;

namespace BlazorLeaflet.Models
{
    public class Polyline : Path
    {

        public PointF[][] Shape { get; set; }

        /// <summary>
        /// How much to simplify the polyline on each zoom level. More means better performance and smoother look, and less means more accurate representation.
        /// </summary>
        public double SmoothFactory { get; set; } = 1.0;

        /// <summary>
        /// Disable polyline clipping.
        /// </summary>
        public bool NoClipEnabled { get; set; }

    }
}
