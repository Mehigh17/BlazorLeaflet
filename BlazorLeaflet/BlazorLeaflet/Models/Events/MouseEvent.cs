using System.Drawing;

namespace BlazorLeaflet.Models.Events
{
    public class MouseEvent : Event
    {
        public LatLng LatLng { get; set; }

        public PointF LayerPoint { get; set; }

        public PointF ContainerPoint { get; set; }

    }
}
