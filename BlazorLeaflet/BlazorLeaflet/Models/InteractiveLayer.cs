namespace BlazorLeaflet.Models
{
    public abstract class InteractiveLayer : Layer
    {

        /// <summary>
        /// If false, the layer will not emit mouse events and will act as a part of the underlying map. (events currently not implemented in BlazorLeaflet)
        /// </summary>
        public bool IsInteractive { get; set; } = true;

        /// <summary>
        /// When true, a mouse event on this layer will trigger the same event on the map (unless L.DomEvent.stopPropagation is used).
        /// </summary>
        public virtual bool IsBubblingMouseEvents { get; set; } = true;

    }
}
