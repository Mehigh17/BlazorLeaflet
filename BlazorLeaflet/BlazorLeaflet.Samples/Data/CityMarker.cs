using BlazorLeaflet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLeaflet.Samples.Data
{
	public class CityMarker : Marker
	{
		public CityMarker(City city) : base(city.Coordinates)
		{
			Icon = new Icon
			{
				Url = city.CoatOfArmsImageUrl,
				ClassName = "map-icon",
			};
			Tooltip = new Tooltip
			{
				Content = city.Name,
			};
			Popup = new Popup
			{
				Content = city.Description,
			};
		}
	}
}
