using System.Runtime.Serialization;

namespace BlazorLeaflet.Models
{
	public class Bounds
	{
		[DataMember(Name = "_northEast")]
		public LatLng NorthEast { get; set; }

		[DataMember(Name = "_southWest")]
		public LatLng SouthWest { get; set; }

		public Bounds() { }
		public Bounds(LatLng southWest, LatLng northEast)
		{
			NorthEast = northEast;
			SouthWest = southWest;
		}

		public override string ToString() =>
			$"NE: {NorthEast.Lat} N, {NorthEast.Lng} E; SW: {SouthWest.Lat} N, {SouthWest.Lng} E";
	}
}
