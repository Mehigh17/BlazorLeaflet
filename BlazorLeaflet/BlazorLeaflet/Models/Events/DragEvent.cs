namespace BlazorLeaflet.Models.Events
{
	public class DragEvent : Event
	{
		public LatLng LatLng { get; set; }

		public LatLng OldLatLng { get; set; }
	}
}
