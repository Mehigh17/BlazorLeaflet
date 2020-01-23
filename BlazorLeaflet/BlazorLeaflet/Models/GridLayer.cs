using BlazorLeaflet.Models.Events;
using Microsoft.JSInterop;
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
        /// If set, tiles will only be loaded inside the set.
        /// </summary>
        public Tuple<double, double> Bounds { get; set; }

        #region events

        public event EventHandler OnLoading;

        [JSInvokable]
        public void NotifyLoading(Event eventArgs)
        {
            OnLoading?.Invoke(this, eventArgs);
        }

        public event TileEventHandler OnTileUnload;

        [JSInvokable]
        public void NotifyTileUnload(TileEvent eventArgs)
        {
            OnTileUnload?.Invoke(this, eventArgs);
        }

        public event TileEventHandler OnTileLoadStart;

        [JSInvokable]
        public void NotifyileLoadStart(TileEvent eventArgs)
        {
            OnTileLoadStart?.Invoke(this, eventArgs);
        }

        public event TileErrorEventHandler OnTileError;

        [JSInvokable]
        public void NotifyTileError(TileErrorEvent eventArgs)
        {
            OnTileError?.Invoke(this, eventArgs);
        }

        public event TileEventHandler OnTileLoad;

        [JSInvokable]
        public void NotifyTileLoad(TileEvent eventArgs)
        {
            OnTileLoad?.Invoke(this, eventArgs);
        }

        public event TileEventHandler OnLoad;

        [JSInvokable]
        public void NotifyLoad(TileEvent eventArgs)
        {
            OnLoad?.Invoke(this, eventArgs);
        }

        #endregion

    }
}
