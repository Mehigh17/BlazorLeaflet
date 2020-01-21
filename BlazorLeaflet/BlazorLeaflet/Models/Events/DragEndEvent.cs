using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLeaflet.Models.Events
{
    public class DragEndEvent : Event
    {
        public float Distance { get; set; }
    }
}
