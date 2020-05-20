<div align="center">
    <img src="media/logo.png" width=300>
    <h1>Blazor Leaflet</h1>
    <div>
        <a href="#description">Description</a> •
        <a href="#installation">Installation</a> •
        <a href="#samples">Samples</a> •
        <a href="#contribute">Contribute</a> •
        <a href="https://mehigh17.github.io/BlazorLeaflet">API Doc</a>
    </div>
</div>

# Description

BlazorLeaflet is a wrapper offering easy-to-use Blazor components that expose the <a href="https://leafletjs.com/">Leaflet API</a> in C#. It allows you to create easily customizable maps without getting outside your existing .NET ecosystem.

The wrapper is still in its early days so it's very lackluster and doesn't expose the entirety of leaflet's API.

Check out the samples project to learn how to use it.

<img src="media/example1.gif" height=400>

# Installation

Install the package in the target project:

```
dotnet add package BlazorLeaflet
```

In your `_Host.cshtml` (Blazor Server) or `index.html` (Blazor WebAssembly), reference the interoperability script in the `<head>` element like so:

```html
<script src="_content/BlazorLeaflet/leafletBlazorInterops.js"></script>
```

You can now use the components and the rest of the library.

# Samples

Create the map

```html
<!-- You must wrap the map component in a container setting its actual size. -->
<div id="mapContainer" style="width: 300px; height: 300px;">
    <LeafletMap Map="_map" />
</div>
```

Bind the parameters to the respective objects like so

```cs
private Map _map = new Map(jsRuntime);
private PointF _startAt = new PointF(47.5574007f, 16.3918687f);
```

Add a marker with a tooltip and an icon

```cs
// Create the marker
var marker = new Marker(0.23f, 32f);
marker.Tooltip = new Tooltip { Content = "This is a nice location!" };
marker.Icon = new Icon { Url = "... some url" };

// Add it to the layers collection
_map.AddLayer(marker);
```

Or add a rectangle that highlights a zone

```cs
var rect = new Rectangle { Shape = new RectangleF(21f, 20f, 10f, 20f) };
rect.Fill = true; // This will fill the rectangle with a color
rect.FillColor = Color.Red; // Make the filled area red
rect.Popup = new Popup { Content = "This is a restricted area!" }; // Create a popup when the area is clicked

// Add it to the layers collection
_map.RemoveAdd(rect);
```

Or fit bounds on certain corners

```cs
_map.FitBounds(new PointF(45.943f, 24.967f), new PointF(46.943f, 25.967f), maxZoom: 5f);
```

# Contribute

The `master` branch is used as the development branch. If you are looking for a specific release, check the tags. If you are willing to contribute, fork this repository, and create your own branch from master, preferably give it a meaningful name, regarding your change or the issue that you are targeting. For large modifications, create an issue before, and a WIP pull request. Always rebase before review requests.
