using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlazorLeaflet.Models.Events
{
    public class TileEvent : Event
    {
        /// <summary>
        /// https://leafletjs.com/reference-1.6.0.html#tileevent states that it is a HTMLElement
        /// </summary>
        public object Title { get; set; }

        public Point Point { get; set; }
    }

    public class TileErrorEvent : TileEvent
    {
        /// <summary>
        /// https://leafletjs.com/reference-1.6.0.html#tileerrorevent states that the type is * ( => could be everything)
        /// </summary>
        public object Error { get; set; }
    }
}
