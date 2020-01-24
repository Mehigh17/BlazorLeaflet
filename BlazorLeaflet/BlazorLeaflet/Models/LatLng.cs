using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLeaflet.Models
{
    public class LatLng
    {
        public decimal Lat { get; set; }

        public decimal Lng { get; set; }

        public decimal Alt { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" (Lat: {Lat}, Lng: {Lng}, Alt: {Alt})";
        }
    }
}
