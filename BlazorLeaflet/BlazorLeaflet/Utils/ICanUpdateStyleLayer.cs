namespace BlazorLeaflet.Utils
{
    /// <summary>
    /// Interface to make sure SetStyle is only called on leaflet layers actually supporting it.
    /// https://leafletjs.com/reference-1.6.0.html
    /// </summary>
    public interface ICanUpdateStyleLayer
    {
        string Id { get; }
    }
}
