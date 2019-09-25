using BlazorLeaflet.Utils;

namespace BlazorLeaflet.Models
{
    public abstract class Layer
    {

        /// <summary>
        /// Unique identifier used by the interoperability service on the client side to identify layers.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// By default the layer will be added to the map's overlay pane. Overriding this option will cause the layer to be placed on another pane by default.
        /// </summary>
        public virtual string Pane { get; set; } = "overlayPane";

        /// <summary>
        /// String to be shown in the attribution control, e.g. "© OpenStreetMap contributors". It describes the layer data and is often a legal obligation towards copyright holders and tile providers.
        /// </summary>
        public string Attribution { get; set; }

        /// <summary>
        /// The tooltip assigned to this marker.
        /// </summary>
        public Tooltip Tooltip { get; set; }

        /// <summary>
        /// The popup shown when the marker is clicked.
        /// </summary>
        public Popup Popup { get; set; }

        protected Layer()
        {
            Id = StringHelper.GetRandomString(20);
        }

    }
}
