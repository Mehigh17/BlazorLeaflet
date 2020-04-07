using System.Drawing;

namespace BlazorLeaflet.Models
{
    public class Circle : Path
    {

        /// <summary>
        /// Center of the circle.
        /// </summary>
        public LatLng Position { get; set; }

        /// <summary>
        /// Radius of the circle, in meters.
        /// </summary>
        public float Radius { get; set; }

    }
}
