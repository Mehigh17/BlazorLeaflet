using System;
using System.Drawing;

namespace BlazorLeaflet.Models
{
    public abstract class GridLayer : Layer
    {

        /// <summary>
        /// Width and height of tiles in the grid.
        /// </summary>
        public Size Size { get; set; } = new Size(256, 256);

        public double Opacity { get; set; } = 1.0;

        /// <summary>
        /// By default, a smooth zoom animation will update grid layers every integer zoom level. Setting this option to false will update the grid layer only when the smooth animation ends.
        /// </summary>
        public bool UpdateWhenZooming { get; set; } = true;

        /// <summary>
        /// Tiles will not update more than once every updateInterval milliseconds when panning.
        /// </summary>
        public int UpdateInterval { get; set; } = 200;

        public int ZIndex { get; set; } = 1;

        /// <summary>
        /// Minimum zoom number the tile source has available. If it is specified, the tiles on all zoom levels lower than minNativeZoom will be loaded from minNativeZoom level and auto-scaled.
        /// </summary>
        public double? MinNativeZoom { get; set; }

        /// <summary>
        ///  Maximum zoom number the tile source has available. If it is specified, the tiles on all zoom levels higher than maxNativeZoom will be loaded from maxNativeZoom level and auto-scaled.
        /// </summary>
        public double? MaxNativeZoom { get; set; }

        /// <summary>
        /// If set, tiles will only be loaded inside the set.
        /// </summary>
        public Tuple<double, double> Bounds { get; set; }

    }
}
