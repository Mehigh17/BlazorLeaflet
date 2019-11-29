using System;
using BlazorLeaflet.Models;
using BlazorLeaflet.Utils;
using System.Collections.ObjectModel;
using System.Drawing;
using Microsoft.JSInterop;

namespace BlazorLeaflet
{
    public class Map
    {

        public string Id { get; }
        public ObservableCollection<Layer> Layers { get; set; } = new ObservableCollection<Layer>();

        private readonly IJSRuntime _jsRuntime;

        public Map(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
            Id = StringHelper.GetRandomString(10);
        }

        public void FitBounds(PointF corner1, PointF corner2)
        {
            LeafletInterops.FitBounds(_jsRuntime, Id, corner1, corner2);
        }

    }
}
