using BlazorLeaflet.Models;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorLeaflet
{
    public static class LeafletInterops
    {

        private static readonly string _BaseObjectContainer = "window.leafletBlazor";

        public static ValueTask Create(IJSRuntime jsRuntime, string elementId)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.create", elementId);
        }

        public static ValueTask AddLayer(IJSRuntime jsRuntime, string elementId, Layer layer)
        {
            if(layer is TileLayer tileLayer)
            {
                return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addTilelayer", elementId, tileLayer);
            }

            throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented.");
        }

        public static ValueTask AddMarker(IJSRuntime jsRuntime, string elementId, Marker marker)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addMarker", elementId, marker);
        }

        public static ValueTask RemoveMarker(IJSRuntime jsRuntime, string mapId, Marker marker)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.removeMarker", mapId, marker.Id);
        }

        public static ValueTask ClearMarkers(IJSRuntime jsRuntime, string mapId)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.clearMarkers", mapId);
        }

    }
}
