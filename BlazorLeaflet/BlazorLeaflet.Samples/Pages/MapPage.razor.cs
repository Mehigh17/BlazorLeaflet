using System.Drawing;
using BlazorLeaflet.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorLeaflet.Samples.Pages;

public partial class MapPage
{
    [Inject] IJSRuntime JsRuntime { get; set; } = default!;
    private Map? Map { get; set; }

    private readonly ImageLayer _imgLayer = new("/img/placio.jpg",
        new PointF(54.30965067305515f, 9.671299274981452f),
        new PointF(54.30945977542981f, 9.672376576355745f))
    {
        IsInteractive = false
    };

    protected override void OnInitialized()
    {
        Map = new Map(JsRuntime)
        {
            Center = new LatLng(54.3096351f, 9.6714511f),
            Zoom = 14f,
            MaxZoom = 19f
        };

        Map.OnInitialized += () =>
        {
            Map.AddLayer(new TileLayer
            {
                UrlTemplate = "https://a.tile.openstreetmap.org/{z}/{x}/{y}.png",
                Attribution =
                    "&copy; <a href=\"https://www.openstreetmap.org/copyright\">OpenStreetMap</a> contributors",
                MaximumZoom = 19f
            });

            Map.AddLayer(_imgLayer);
        };
        Map.OnBoundsChanged += (s, e) => StateHasChanged();
    }

    private void ToggleInteractive()
    {
        Map!.RemoveLayer(_imgLayer);
        _imgLayer.IsInteractive = !_imgLayer.IsInteractive;
        Map.AddLayer(_imgLayer);
    }
}