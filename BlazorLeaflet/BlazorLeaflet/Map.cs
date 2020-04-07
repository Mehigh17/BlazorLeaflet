using System;
using BlazorLeaflet.Models;
using BlazorLeaflet.Utils;
using System.Collections.ObjectModel;
using System.Drawing;
using Microsoft.JSInterop;
using BlazorLeaflet.Models.Events;
using System.Threading.Tasks;

namespace BlazorLeaflet
{
    public class Map
    {
        /// <summary>
        /// Initial geographic center of the map
        /// </summary>
        public LatLng Center { get; set; } = new LatLng();

        /// <summary>
        /// Initial map zoom level
        /// </summary>
        public float Zoom { get; set; }

        /// <summary>
        /// Minimum zoom level of the map. If not specified and at least one 
        /// GridLayer or TileLayer is in the map, the lowest of their minZoom
        /// options will be used instead.
        /// </summary>
        public float? MinZoom { get; set; }

        /// <summary>
        /// Maximum zoom level of the map. If not specified and at least one
        /// GridLayer or TileLayer is in the map, the highest of their maxZoom
        /// options will be used instead.
        /// </summary>
        public float? MaxZoom { get; set; }

        /// <summary>
        /// When this option is set, the map restricts the view to the given
        /// geographical bounds, bouncing the user back if the user tries to pan
        /// outside the view. 
        /// </summary>
        public Tuple<LatLng, LatLng> MaxBounds { get; set; }

        public string Id { get; }
        public ObservableCollection<Layer> Layers { get; set; } = new ObservableCollection<Layer>();

        private readonly IJSRuntime _jsRuntime;

        public Map(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
            Id = StringHelper.GetRandomString(10);
        }

        public void FitBounds(PointF corner1, PointF corner2, PointF? padding = null, float? maxZoom = null)
        {
            LeafletInterops.FitBounds(_jsRuntime, Id, corner1, corner2, padding, maxZoom);
        }

        public void PanTo(PointF position, bool animate = false, float duration = 0.25f, float easeLinearity = 0.25f, bool noMoveStart = false)
        {
            LeafletInterops.PanTo(_jsRuntime, Id, position, animate, duration, easeLinearity, noMoveStart);
        }

        public async Task<LatLng> GetCenter() => await LeafletInterops.GetCenter(_jsRuntime, Id);
        public async Task<float> GetZoom() => await LeafletInterops.GetZoom(_jsRuntime, Id);

        #region events

        public delegate void MapEventHandler(object sender, Event e);
        public delegate void MapResizeEventHandler(object sender, ResizeEvent e);

        public event MapEventHandler OnZoomLevelsChange;
        [JSInvokable]
        public void NotifyZoomLevelsChange(Event e) => OnZoomLevelsChange?.Invoke(this, e);

        public event MapResizeEventHandler OnResize;
        [JSInvokable]
        public void NotifyResize(ResizeEvent e) => OnResize?.Invoke(this, e);

        public event MapEventHandler OnUnload;
        [JSInvokable]
        public void NotifyUnload(Event e) => OnUnload?.Invoke(this, e);

        public event MapEventHandler OnViewReset;
        [JSInvokable]
        public void NotifyViewReset(Event e) => OnViewReset?.Invoke(this, e);

        public event MapEventHandler OnLoad;
        [JSInvokable]
        public void NotifyLoad(Event e) => OnLoad?.Invoke(this, e);

        public event MapEventHandler OnZoomStart;
        [JSInvokable]
        public void NotifyZoomStart(Event e) => OnZoomStart?.Invoke(this, e);

        public event MapEventHandler OnMoveStart;
        [JSInvokable]
        public void NotifyMoveStart(Event e) => OnMoveStart?.Invoke(this, e);

        public event MapEventHandler OnZoom;
        [JSInvokable]
        public void NotifyZoom(Event e) => OnZoom?.Invoke(this, e);

        public event MapEventHandler OnMove;
        [JSInvokable]
        public void NotifyMove(Event e) => OnMove?.Invoke(this, e);

        public event MapEventHandler OnZoomEnd;
        [JSInvokable]
        public void NotifyZoomEnd(Event e) => OnZoomEnd?.Invoke(this, e);

        public event MapEventHandler OnMoveEnd;
        [JSInvokable]
        public void NotifyMoveEnd(Event e) => OnMoveEnd?.Invoke(this, e);

        public event MouseEventHandler OnMouseMove;
        [JSInvokable]
        public void NotifyMouseMove(MouseEvent eventArgs) => OnMouseMove?.Invoke(this, eventArgs);

        public event MapEventHandler OnKeyPress;
        [JSInvokable]
        public void NotifyKeyPress(Event eventArgs) => OnKeyPress?.Invoke(this, eventArgs);

        public event MapEventHandler OnKeyDown;
        [JSInvokable]
        public void NotifyKeyDown(Event eventArgs) => OnKeyDown?.Invoke(this, eventArgs);

        public event MapEventHandler OnKeyUp;
        [JSInvokable]
        public void NotifyKeyUp(Event eventArgs) => OnKeyUp?.Invoke(this, eventArgs);

        public event MouseEventHandler OnPreClick;
        [JSInvokable]
        public void NotifyPreClick(MouseEvent eventArgs) => OnPreClick?.Invoke(this, eventArgs);

        #region InteractiveLayerEvents
        // Has the same events as InteractiveLayer, but it is not a layer. 
        // Could place this code in its own class and make Layer inherit from that, but not every layer is interactive...
        // Is there a way to not duplicate this code?

        public delegate void MouseEventHandler(Map sender, MouseEvent e);

        public event MouseEventHandler OnClick;
        [JSInvokable]
        public void NotifyClick(MouseEvent eventArgs) => OnClick?.Invoke(this, eventArgs);

        public event MouseEventHandler OnDblClick;
        [JSInvokable]
        public void NotifyDblClick(MouseEvent eventArgs) => OnDblClick?.Invoke(this, eventArgs);

        public event MouseEventHandler OnMouseDown;
        [JSInvokable]
        public void NotifyMouseDown(MouseEvent eventArgs) => OnMouseDown?.Invoke(this, eventArgs);

        public event MouseEventHandler OnMouseUp;
        [JSInvokable]
        public void NotifyMouseUp(MouseEvent eventArgs) => OnMouseUp?.Invoke(this, eventArgs);

        public event MouseEventHandler OnMouseOver;
        [JSInvokable]
        public void NotifyMouseOver(MouseEvent eventArgs) => OnMouseOver?.Invoke(this, eventArgs);

        public event MouseEventHandler OnMouseOut;
        [JSInvokable]
        public void NotifyMouseOut(MouseEvent eventArgs) => OnMouseOut?.Invoke(this, eventArgs);

        public event MouseEventHandler OnContextMenu;
        [JSInvokable]
        public void NotifyContextMenu(MouseEvent eventArgs) => OnContextMenu?.Invoke(this, eventArgs);
        #endregion InteractiveLayerEvents

        #endregion
    }
}
