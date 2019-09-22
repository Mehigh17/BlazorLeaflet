namespace BlazorLeaflet.Models
{
    public abstract class Layer
    {

        /// <summary>
        /// By default the layer will be added to the map's overlay pane. Overriding this option will cause the layer to be placed on another pane by default.
        /// </summary>
        public string Pane { get; set; } = "overlayPane";

        /// <summary>
        /// String to be shown in the attribution control, e.g. "© OpenStreetMap contributors". It describes the layer data and is often a legal obligation towards copyright holders and tile providers.
        /// </summary>
        public string Attribution { get; set; }

    }
}
