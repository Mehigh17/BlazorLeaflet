using BlazorLeaflet.Models;
using Microsoft.JSInterop;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace BlazorLeaflet
{
    public static class LeafletInterops
    {

        private static readonly string _BaseObjectContainer = "window.leafletBlazor";

        public static ValueTask Create(IJSRuntime jsRuntime, string mapId, PointF initCenterPosition, float initialZoom)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.create", mapId, initCenterPosition, initialZoom);
        }

        public static ValueTask AddLayer(IJSRuntime jsRuntime, string mapId, Layer layer)
        {
            if(layer is TileLayer tileLayer)
            {
                return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addTilelayer", mapId, tileLayer);
            }

            if (layer is Marker marker)
            {
                return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addMarker", mapId, marker);
            }

            throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented.");
        }

        public static ValueTask RemoveLayer(IJSRuntime jsRuntime, string mapId, string layerId)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.removeLayer", mapId, layerId);
        }

    }
}
