using BlazorLeaflet.Models;
using Microsoft.JSInterop;
using System;
using System.Drawing;
using System.Threading.Tasks;
using Rectangle = BlazorLeaflet.Models.Rectangle;

namespace BlazorLeaflet
{
    public static class LeafletInterops
    {
        private static readonly string _BaseObjectContainer = "window.leafletBlazor";

        public static ValueTask Create(IJSRuntime jsRuntime, string mapId, MapArgs args)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.create", mapId, args, DotNetObjectReference.Create(args));
        }

        public static ValueTask<bool> IsLoaded(IJSRuntime jsRuntime, string mapId)
        {
            return jsRuntime.InvokeAsync<bool>($"{_BaseObjectContainer}.isLoaded", mapId);
        }
        
        public static ValueTask AddLayer(IJSRuntime jsRuntime, string mapId, Layer layer) =>
            layer switch
            {
                TileLayer tileLayer => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addTilelayer", mapId, tileLayer, DotNetObjectReference.Create(tileLayer)),
                Marker marker => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addMarker", mapId, marker, DotNetObjectReference.Create(marker)),
                Rectangle rectangle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addRectangle", mapId, rectangle, DotNetObjectReference.Create(rectangle)),
                Circle circle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addCircle", mapId, circle, DotNetObjectReference.Create(circle)),
                Polygon polygon => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addPolygon", mapId, polygon, DotNetObjectReference.Create(polygon)),
                Polyline polyline => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addPolyline", mapId, polyline, DotNetObjectReference.Create(polyline)),
                ImageLayer image => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addImageLayer", mapId, image, DotNetObjectReference.Create(image)),
                _ => throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented."),
            };

        public static ValueTask RemoveLayer(IJSRuntime jsRuntime, string mapId, string layerId)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.removeLayer", mapId, layerId);
        }

        public static ValueTask FitBounds(IJSRuntime jsRuntime, string mapId, PointF corner1, PointF corner2, PointF? padding, float? maxZoom)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.fitBounds", mapId, corner1, corner2, padding, maxZoom);
        }

        public static ValueTask PanTo(IJSRuntime jsRuntime, string mapId, PointF position, bool animate, float duration, float easeLinearity, bool noMoveStart)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.panTo", mapId, position, animate, duration, easeLinearity, noMoveStart);
        }
        
        public static ValueTask SetMaxBounds(IJSRuntime jsRuntime, string mapId, PointF corner1, PointF corner2)
        {
            return jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.setMaxBounds", mapId, corner1, corner2);
        }
    }
}
