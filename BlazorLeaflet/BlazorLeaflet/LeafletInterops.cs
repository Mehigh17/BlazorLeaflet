using BlazorLeaflet.Models;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorLeaflet
{
    public static class LeafletInterops
    {

        private static readonly string _BaseObjectContainer = "window.leafletBlazor";

        public static ValueTask Create(IJSRuntime jsRuntime, string mapId, System.Drawing.PointF initCenterPosition, float initialZoom)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.create", mapId, initCenterPosition, initialZoom);
        }

        public static ValueTask AddLayer(IJSRuntime jsRuntime, string mapId, Layer layer) =>
            layer switch
            {
                TileLayer tileLayer => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addTilelayer", mapId, tileLayer),
                Marker marker => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addMarker", mapId, marker),
                Rectangle rectangle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addRectangle", mapId, rectangle),
                Circle circle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addCircle", mapId, circle),
                Polygon polygon => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addPolygon", mapId, polygon),
                Polyline polyline => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addPolyline", mapId, polyline),
                _ => throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented."),
            };

        public static ValueTask RemoveLayer(IJSRuntime jsRuntime, string mapId, string layerId)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.removeLayer", mapId, layerId);
        }

    }
}
