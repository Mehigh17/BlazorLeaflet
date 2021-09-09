using BlazorLeaflet.Exceptions;
using BlazorLeaflet.Models.Events;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;

namespace BlazorLeaflet.Models
{
    public class MarkerClusterLayer : Layer
    {
        public List<Marker> MarkersLayers { get; protected set; } = new List<Marker>();

        public void AddLayer(Marker layer)
        {
            if (layer is null)
            {
                throw new ArgumentNullException(nameof(layer));
            }

            MarkersLayers.Add(layer);
        }

        public void RemoveLayer(Marker layer)
        {
            if (layer is null)
            {
                throw new ArgumentNullException(nameof(layer));
            }

            MarkersLayers.Remove(layer);
        }

        public int DisableClusteringAtZoom { get; set; }

        #region events

        public delegate void EventHandler(Layer sender, Event e);

        public event EventHandler OnAdd;

        [JSInvokable]
        public void NotifyAdd(Event eventArgs) => OnAdd?.Invoke(this, eventArgs);

        public event EventHandler OnRemove;

        [JSInvokable]
        public void NotifyRemove(Event eventArgs) => OnRemove?.Invoke(this, eventArgs);

        public delegate void PopupEventHandler(Layer sender, PopupEvent e);

        public event PopupEventHandler OnPopupOpen;

        [JSInvokable]
        public void NotifyPopupOpen(PopupEvent eventArgs) => OnPopupOpen?.Invoke(this, eventArgs);

        public event PopupEventHandler OnPopupClose;

        [JSInvokable]
        public void NotifyPopupClose(PopupEvent eventArgs) => OnPopupClose?.Invoke(this, eventArgs);

        public delegate void TooltipEventHandler(Layer sender, TooltipEvent e);

        public event TooltipEventHandler OnTooltipOpen;

        [JSInvokable]
        public void NotifyTooltipOpen(TooltipEvent eventArgs) => OnTooltipOpen?.Invoke(this, eventArgs);

        public event TooltipEventHandler OnTooltipClose;

        [JSInvokable]
        public void NotifyTooltipClose(TooltipEvent eventArgs) => OnTooltipClose?.Invoke(this, eventArgs);

        #endregion
    }
}
