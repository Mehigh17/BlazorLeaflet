using BlazorLeaflet.Models.Events;
using Microsoft.JSInterop;
using System;
using System.Drawing;

namespace BlazorLeaflet.Models
{
    public class Circle : Path
    {

        /// <summary>
        /// Center of the circle.
        /// </summary>
        public PointF Position { get; set; }

        /// <summary>
        /// Radius of the circle, in meters.
        /// </summary>
        public float Radius { get; set; }

        #region events 

        public event EventHandler OnMove;

        [JSInvokable]
        public void NotifyMove(DragEvent eventArgs)
        {
            Console.WriteLine("NotifyMove");
            OnMove?.Invoke(this, eventArgs);
        }

        #endregion
    }
}
