using System.Drawing;

namespace BlazorLeaflet.Models
{
    public class LatLng
    {
        public float Lat { get; set; }

        public float Lng { get; set; }

        public float Alt { get; set; }

        public PointF ToPointF() => new PointF(Lat, Lng);
    }
}
