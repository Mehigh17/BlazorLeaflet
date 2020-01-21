using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLeaflet.Models.Events
{
    public class ErrorEvent : Event
    {
        public string Message { get; set; }

        public int Code { get; set; }
    }
}
