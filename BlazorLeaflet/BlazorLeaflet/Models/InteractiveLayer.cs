using BlazorLeaflet.Models.Events;
using Microsoft.JSInterop;

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

        #region events

        public delegate void MouseEventHandler(object sender, MouseEvent e);

        public MouseEventHandler OnClick;

        [JSInvokable]
        public void NotifyClick(MouseEvent eventArgs)
        {
            OnClick?.Invoke(this, eventArgs);
        }

        public MouseEventHandler OnDblClick;

        [JSInvokable]
        public void NotifyDblClick(MouseEvent eventArgs)
        {
            OnDblClick?.Invoke(this, eventArgs);
        }

        public MouseEventHandler OnMouseDown;

        [JSInvokable]
        public void NotifyMouseDown(MouseEvent eventArgs)
        {
            OnMouseDown?.Invoke(this, eventArgs);
        }

        public MouseEventHandler OnMouseUp;

        [JSInvokable]
        public void NotifyMouseUp(MouseEvent eventArgs)
        {
            OnMouseUp?.Invoke(this, eventArgs);
        }

        public MouseEventHandler OnMouseOver;

        [JSInvokable]
        public void NotifyMouseOver(MouseEvent eventArgs)
        {
            OnMouseOver?.Invoke(this, eventArgs);
        }

        public MouseEventHandler OnMouseOut;

        [JSInvokable]
        public void NotifyMouseOut(MouseEvent eventArgs)
        {
            OnMouseOut?.Invoke(this, eventArgs);
        }

        public MouseEventHandler OnContextMenu;

        [JSInvokable]
        public void NotifyContextMenu(MouseEvent eventArgs)
        {
            OnContextMenu?.Invoke(this, eventArgs);
        }

        #endregion

    }
}
