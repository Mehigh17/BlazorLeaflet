using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLeaflet.Models.Events
{
    public class TooltipEvent : Event
    {
        public Tooltip Tooltip { get; set; }
    }
}
