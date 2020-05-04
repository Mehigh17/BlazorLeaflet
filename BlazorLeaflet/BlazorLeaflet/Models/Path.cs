using BlazorLeaflet.Utils;
using System.Drawing;

namespace BlazorLeaflet.Models
{
    public abstract class Path : InteractiveLayer, ICanUpdateStyleLayer
    {

        /// <summary>
        /// Whether to draw stroke along the path. Set it to false to disable borders on polygons or circles.
        /// </summary>
        public bool DrawStroke { get; set; } = true;

        /// <summary>
        /// Stroke color.
        /// </summary>
        public Color StrokeColor { get; set; } = Color.FromArgb(0x33, 0x88, 0xFF);

        /// <summary>
        /// Stroke width.
        /// </summary>
        public int StrokeWidth { get; set; } = 3;

        /// <summary>
        /// Stroke opacity.
        /// </summary>
        public double StrokeOpacity { get; set; } = 1.0;

        /// <summary>
        /// A string that defines <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-linecap">shape to be used at the end</see> of the stroke.
        /// </summary>
        public string LineCap { get; set; } = "round";

        /// <summary>
        /// A string that defines <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-linejoin">shape to be used at the corners</see> of the stroke.
        /// </summary>
        public string LineJoin { get; set; } = "round";

        /// <summary>
        /// A string that defines the stroke <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-dasharray">dash pattern</see>. Doesn't work on Canvas-powered layers in some old browsers.
        /// </summary>
        public string StrokeDashArray { get; set; }

        /// <summary>
        /// A string that <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/stroke-dashoffset">defines the distance into the dash pattern to start the dash</see>. Doesn't work on Canvas-powered layers in some old browsers.
        /// </summary>
        public string StrokeDashOffset { get; set; }

        /// <summary>
        /// Whether to fill the path with color. Set it to false to disable filling on polygons or circles.
        /// </summary>
        public bool Fill { get; set; }

        /// <summary>
        /// Fill color. Defaults to the value of the color option
        /// </summary>
        public Color FillColor { get; set; }

        /// <summary>
        /// Fill opacity.
        /// </summary>
        public double FillOpacity { get; set; } = 0.2;

        /// <summary>
        /// A string that defines <see href="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/fill-rule">how the inside of a shape</see> is determined.
        /// </summary>
        public string FillRule { get; set; } = "evenodd";

    }
}
