using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLeaflet.Models
{
    public class GeoJsonDataLayer : InteractiveLayer
    {
        public string GeoJsonData { get; set; }

        public bool HasPointToLayerFunc => PointToLayer != null;

        [System.Text.Json.Serialization.JsonIgnore]
        public Func<object, LatLng, Marker> PointToLayer { get; set; }

        [JSInvokable]
        public object CallPointToLayer(object point, LatLng latLng)
        {
            var layer = PointToLayer(point, latLng);

            if (!(layer is Marker))
                throw new NotSupportedException("Only Marker layers are currently implemented for PointToLayer.");

            return new { Layer = layer, Ref = DotNetObjectReference.Create(layer) };
        }
    }
}
