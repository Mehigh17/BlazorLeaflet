using BlazorLeaflet.Models;
using BlazorLeaflet.Utils;
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

        public static ValueTask Create(IJSRuntime jsRuntime, Map map) =>
            jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.create", map, DotNetObjectReference.Create(map));

        public static ValueTask AddLayer(IJSRuntime jsRuntime, string mapId, Layer layer) =>
            layer switch
            {
                TileLayer tileLayer => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addTilelayer", mapId, tileLayer, DotNetObjectReference.Create(tileLayer)),
                MbTilesLayer mbTilesLayer => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addMbTilesLayer", mapId, mbTilesLayer, DotNetObjectReference.Create(mbTilesLayer)),
                ShapefileLayer shapefileLayer => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addShapefileLayer", mapId, shapefileLayer, DotNetObjectReference.Create(shapefileLayer)),
                Marker marker => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addMarker", mapId, marker, DotNetObjectReference.Create(marker)),
                Rectangle rectangle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addRectangle", mapId, rectangle, DotNetObjectReference.Create(rectangle)),
                Circle circle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addCircle", mapId, circle, DotNetObjectReference.Create(circle)),
                Polygon polygon => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addPolygon", mapId, polygon, DotNetObjectReference.Create(polygon)),
                Polyline polyline => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addPolyline", mapId, polyline, DotNetObjectReference.Create(polyline)),
                ImageLayer image => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addImageLayer", mapId, image, DotNetObjectReference.Create(image)),
                GeoJsonDataLayer geo => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.addGeoJsonLayer", mapId, geo, DotNetObjectReference.Create(geo)),
                _ => throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented."),
            };

        public static ValueTask RemoveLayer(IJSRuntime jsRuntime, string mapId, string layerId) =>
            jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.removeLayer", mapId, layerId);

        public static ValueTask UpdatePopupContent(IJSRuntime jsRuntime, string mapId, Layer layer) =>
            jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.updatePopupContent", mapId, layer.Id, layer.Popup?.Content);

        public static ValueTask UpdateTooltipContent(IJSRuntime jsRuntime, string mapId, Layer layer) =>
            jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.updateTooltipContent", mapId, layer.Id, layer.Tooltip?.Content);

        public static ValueTask UpdateStyleContent(IJSRuntime jsRuntime, string mapId, ICanUpdateStyleLayer layer, Style style) =>
            jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.updateStyleContent", mapId, layer.Id, style);

        public static ValueTask UpdateShape(IJSRuntime jsRuntime, string mapId, Layer layer) =>
            layer switch
            {
                Rectangle rectangle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.updateRectangle", mapId, rectangle),
                Circle circle => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.updateCircle", mapId, circle),
                Polygon polygon => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.updatePolygon", mapId, polygon),
                Polyline polyline => jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.updatePolyline", mapId, polyline),
                _ => throw new NotImplementedException($"The layer {typeof(Layer).Name} has not been implemented."),
            };

        public static ValueTask FitBounds(IJSRuntime jsRuntime, string mapId, PointF corner1, PointF corner2, PointF? padding, float? maxZoom) =>
            jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.fitBounds", mapId, corner1, corner2, padding, maxZoom);

        public static ValueTask PanTo(IJSRuntime jsRuntime, string mapId, PointF position, bool animate, float duration, float easeLinearity, bool noMoveStart) =>
            jsRuntime.InvokeVoidAsync($"{_BaseObjectContainer}.panTo", mapId, position, animate, duration, easeLinearity, noMoveStart);

        public static ValueTask<LatLng> GetCenter(IJSRuntime jsRuntime, string mapId) =>
            jsRuntime.InvokeAsync<LatLng>($"{_BaseObjectContainer}.getCenter", mapId);

        public static ValueTask<float> GetZoom(IJSRuntime jsRuntime, string mapId) =>
            jsRuntime.InvokeAsync<float>($"{_BaseObjectContainer}.getZoom", mapId);
    }
}
