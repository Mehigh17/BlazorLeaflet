namespace BlazorLeaflet.Models.Events
{
	public class ErrorEvent : Event
	{
		public string Message { get; set; }

		public int Code { get; set; }
	}
}
