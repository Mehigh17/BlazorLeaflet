using BlazorLeaflet.Utils;
using System.Drawing;

namespace BlazorLeaflet.Models
{
    public class Marker : InteractiveLayer
    {

        public string Id { get; }

        /// <summary>
        /// The position of the marker on the map.
        /// </summary>
        public PointF Position { get; set; }

        /// <summary>
        /// Icon instance to use for rendering the marker. See <see href="https://leafletjs.com/reference-1.5.0.html#icon">Icon documentation</see> for details on how to customize the marker icon. If not specified, a common instance of <see href="https://leafletjs.com/reference-1.5.0.html#icon-default">L.Icon.Default</see> is used.
        /// </summary>
        public Icon Icon { get; set; }

        /// <summary>
        /// Whether the marker can be tabbed to with a keyboard and clicked by pressing enter.
        /// </summary>
        public bool IsKeyboardAccessible { get; set; } = true;

        /// <summary>
        /// Text for the browser tooltip that appear on marker hover (no tooltip by default).
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Text for the alt attribute of the icon image (useful for accessibility).
        /// </summary>
        public string Alt { get; set; } = string.Empty;

        /// <summary>
        /// By default, marker images zIndex is set automatically based on its latitude. Use this option if you want to put the marker on top of all others (or below), specifying a high value like 1000 (or high negative value, respectively).
        /// </summary>
        public int ZIndexOffset { get; set; }

        /// <summary>
        /// The opacity of the marker.
        /// </summary>
        public double Opacity { get; set; } = 1.0;

        /// <summary>
        /// If true, the marker will get on top of others when you hover the mouse over it.
        /// </summary>
        public bool RiseOnHover { get; set; }

        /// <summary>
        /// The z-index offset used for the riseOnHover feature.
        /// </summary>
        public int RiseOffset { get; set; } = 250;

        public override string Pane { get; set; } = "markerPane";

        public override bool IsBubblingMouseEvents { get; set; } = false;

        /// <summary>
        /// Whether the marker is draggable with mouse/touch or not.
        /// </summary>
        public bool Draggable { get; set; }

        /// <summary>
        /// Whether to pan the map when dragging this marker near its edge or not.
        /// </summary>
        public bool UseAutoPan { get; set; }

        /// <summary>
        /// Distance (in pixels to the left/right and to the top/bottom) of the map edge to start panning the map.
        /// </summary>
        public Point AutoPanPadding { get; set; } = new Point(50, 50);

        /// <summary>
        /// Number of pixels the map should pan by.
        /// </summary>
        public int AutoPanSpeed { get; set; } = 10;

        public Marker(float x, float y) : this(new PointF(x, y))
        {
        }

        public Marker(PointF position)
        {
            Position = position;
            Id = StringHelper.GetRandomString(20);
        }

    }
}
