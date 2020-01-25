using System;
using BlazorLeaflet.Models;
using BlazorLeaflet.Utils;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading.Tasks;
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
        
        public ValueTask<bool> IsLoaded()
        {
            return LeafletInterops.IsLoaded(_jsRuntime, Id);
        }

        public ValueTask FitBounds(PointF corner1, PointF corner2, PointF? padding = null, float? maxZoom = null)
        {
            return LeafletInterops.FitBounds(_jsRuntime, Id, corner1, corner2, padding, maxZoom);
        }
        
        public ValueTask PanTo(PointF position, bool animate = false, float duration = 0.25f, float easeLinearity = 0.25f, bool noMoveStart = false)
        {
            return LeafletInterops.PanTo(_jsRuntime, Id, position, animate, duration, easeLinearity, noMoveStart);
        }

        public ValueTask SetMaxBounds(PointF corner1, PointF corner2)
        {
            return LeafletInterops.SetMaxBounds(_jsRuntime, Id, corner1, corner2);
        }
    }
}
