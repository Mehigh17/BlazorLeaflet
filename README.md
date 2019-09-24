<div align="center">
    <img src="media/logo.png" width=300>
    <h1>Blazor Leaflet</h1>
    <div>
        <a href="#description">Description</a> •
        <a href="#installation">Installation</a> •
        <a href="#samples">Samples</a>
    </div>
</div>

# Description

BlazorLeaflet is a wrapper offering easy-to-use Blazor components that expose the <a href="https://leafletjs.com/">Leaflet API</a> in C#.

The wrapper is still in its early days so it's very lackluster and doesn't expose the entirety of leaflet's API.

Check out the samples project to learn how to use it.

<img src="media/example1.gif" height=400>

# Installation

Install the package in the target project:

```
dotnet add package BlazorLeaflet
```

In your `_Host` file reference the interoperability script in the `<head>` element like so:

```html
<script src="_content/BlazorLeaflet/leafletBlazorInterops.js"></script>
```

You can now use the components and the rest of the library.

# Samples

Create the map

```html
<LeafletMap Layers="_layers" InitialPosition="_startAt" InitialZoom="4.8f" />
```

Bind the parameters to the respective objects

```cs
private PointF _startAt = new PointF(47.5574007f, 16.3918687f);
private ObservableCollection<Layer> _layers = // etc...
```

Storing the layers in an ObservableCollection will automatically update the map as soon as the collection changed.