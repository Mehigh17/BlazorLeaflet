using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLeaflet.Models.Events
{
    public class PopupEvent : Event
    {
        public Popup Popup { get; set; }
    }
}
