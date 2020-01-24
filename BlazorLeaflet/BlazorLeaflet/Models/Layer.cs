using BlazorLeaflet.Models.Events;
using BlazorLeaflet.Utils;
using Microsoft.JSInterop;

namespace BlazorLeaflet.Models
{
    public abstract class Layer
    {
        /// <summary>
        /// Unique identifier used by the interoperability service on the client side to identify layers.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// We need JSRuntime to call methods on the corresponding javascript object
        /// It will be set my LeafletMap when the layer is added to the actual map.
        /// </summary>
        public IJSRuntime JSRuntime { get; internal set; }

        /// <summary>
        /// We need MapId to call methods on the corresponding javascript object.
        /// It will be set my LeafletMap when the layer is added to the actual map.
        /// </summary>
        public string MapId { get; internal set; }

        /// <summary>
        /// By default the layer will be added to the map's overlay pane. Overriding this option will cause the layer to be placed on another pane by default.
        /// </summary>
        public virtual string Pane { get; set; } = "overlayPane";

        /// <summary>
        /// String to be shown in the attribution control, e.g. "© OpenStreetMap contributors". It describes the layer data and is often a legal obligation towards copyright holders and tile providers.
        /// </summary>
        public string Attribution { get; set; }

        /// <summary>
        /// The tooltip assigned to this marker.
        /// </summary>
        public Tooltip Tooltip { get; set; }

        /// <summary>
        /// The popup shown when the marker is clicked.
        /// </summary>
        public Popup Popup { get; set; }

        protected Layer()
        {
            Id = StringHelper.GetRandomString(20);
        }

        #region events

        public delegate void EventHandler(Layer sender, Event e);

        public delegate void TileEventHandler(Layer sender, TileEvent e);

        public delegate void TileErrorEventHandler(Layer sender, TileErrorEvent e);

        public delegate void PopupEventHandler(Layer sender, PopupEvent e);

        public delegate void TooltipEventHandler(Layer sender, TooltipEvent e); 

        public event EventHandler OnAdd;

        [JSInvokable]
        public void NotifyAdd(Event eventArgs)
        {
            OnAdd?.Invoke(this, eventArgs);
        }

        public event EventHandler OnRemove;

        [JSInvokable]
        public void NotifyRemove(Event eventArgs)
        {
            OnRemove?.Invoke(this, eventArgs);
        }

        public event PopupEventHandler OnPopupOpen;

        [JSInvokable]
        public void NotifyPopupOpen(PopupEvent eventArgs)
        {
            OnPopupOpen?.Invoke(this, eventArgs);
        }

        public event PopupEventHandler OnPopupClose;

        [JSInvokable]
        public void NotifyPopupClose(PopupEvent eventArgs)
        {
            OnPopupClose?.Invoke(this, eventArgs);
        }

        public event TooltipEventHandler OnTooltipOpen;

        [JSInvokable]
        public void NotifyTooltipOpen(TooltipEvent eventArgs)
        {
            OnTooltipOpen?.Invoke(this, eventArgs);
        }

        public event TooltipEventHandler OnTooltipClose;

        [JSInvokable]
        public void NotifyTooltipClose(TooltipEvent eventArgs)
        {
            OnTooltipClose?.Invoke(this, eventArgs);
        }

        #endregion
    }
}
