using System.Drawing;

namespace BlazorLeaflet.Models.Events
{
    public class ResizeEvent : Event
    {
        public PointF OldSize { get; set; }
        public PointF NewSize { get; set; }
    }
}
