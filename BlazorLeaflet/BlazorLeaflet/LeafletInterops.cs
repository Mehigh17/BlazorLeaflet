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

        internal static readonly string BaseObjectContainer = "window.leafletBlazor";

        public static ValueTask Create(IJSRuntime jsRuntime, string mapId, System.Drawing.PointF initCenterPosition, float initialZoom)
        {
            return jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.create", mapId, initCenterPosition, initialZoom);
        }

        public static ValueTask AddLayer(IJSRuntime jsRuntime, string mapId, Layer layer) =>
            layer switch
            {
                TileLayer tileLayer => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addTilelayer", mapId, tileLayer, DotNetObjectReference.Create(tileLayer)),
                Marker marker => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addMarker", mapId, marker, DotNetObjectReference.Create(marker)),
                Rectangle rectangle => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addRectangle", mapId, rectangle.ActivateShapeLTRB(), DotNetObjectReference.Create(rectangle)),
                Circle circle => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addCircle", mapId, circle, DotNetObjectReference.Create(circle)),
                Polygon polygon => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addPolygon", mapId, polygon, DotNetObjectReference.Create(polygon)),
                Polyline polyline => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addPolyline", mapId, polyline, DotNetObjectReference.Create(polyline)),
                ImageLayer image => jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.addImageLayer", mapId, image, DotNetObjectReference.Create(image)),
                _ => throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented."),
            };

        public static ValueTask RemoveLayer(IJSRuntime jsRuntime, string mapId, string layerId)
        {
            return jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.removeLayer", mapId, layerId);
        }

        public static ValueTask FitBounds(IJSRuntime jsRuntime, string mapId, PointF corner1, PointF corner2, PointF? padding, float? maxZoom)
        {
            return jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.fitBounds", mapId, corner1, corner2, padding, maxZoom);
        }

        public static ValueTask PanTo(IJSRuntime jsRuntime, string mapId, PointF position, bool animate, float duration, float easeLinearity, bool noMoveStart)
        {
            return jsRuntime.InvokeVoidAsync($"{BaseObjectContainer}.panTo", mapId, position, animate, duration, easeLinearity, noMoveStart);
        }

        /// <summary>
        /// Calls the Rectangle.Shape's Left, Top, Bottom and Right getters once.
        /// If this properties are not called at least once before passing it to javascript, they will not be present in the resulting js object.
        /// </summary>
        private static Rectangle ActivateShapeLTRB(this Rectangle rectangle)
        {
            _ = rectangle.Shape.Left;
            _ = rectangle.Shape.Top;
            _ = rectangle.Shape.Bottom;
            _ = rectangle.Shape.Right;
            return rectangle;
        }

    }
}
