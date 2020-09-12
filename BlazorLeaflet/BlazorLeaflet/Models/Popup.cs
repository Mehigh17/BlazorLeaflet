using System.Drawing;

namespace BlazorLeaflet.Models
{
	public class Popup : DivOverlay
	{

		public override string Pane => "popupPane";

		/// <summary>
		/// Max width of the popup, in pixels.
		/// </summary>
		public int MaximumWidth { get; set; } = 300;

		/// <summary>
		/// Min width of the popup, in pixels.
		/// </summary>
		public int MinimumWidth { get; set; } = 50;

		/// <summary>
		/// If set, creates a scrollable container of the given height inside a popup if its content exceeds it.
		/// </summary>
		public int? MaximumHeight { get; set; }

		/// <summary>
		/// Set it to false if you don't want the map to do panning animation to fit the opened popup.
		/// </summary>
		public bool AutoPanEnabled { get; set; } = true;

		/// <summary>
		/// The margin between the popup and the top left corner of the map view after autopanning was performed.
		/// </summary>
		public Point? AutoPanPaddingTopLeft { get; set; }

		/// <summary>
		/// The margin between the popup and the bottom right corner of the map view after autopanning was performed.
		/// </summary>
		public Point? AutoPanPaddingBottomLeft { get; set; }

		/// <summary>
		/// Equivalent of setting both top left and bottom right autopan padding to the same value.
		/// </summary>
		public Point AutoPanPadding { get; set; } = new Point(5, 5);

		/// <summary>
		/// Set it to true if you want to prevent users from panning the popup off of the screen while it is open.
		/// </summary>
		public bool KeepInView { get; set; }

		/// <summary>
		/// Controls the presence of a close button in the popup.
		/// </summary>
		public bool ShowCloseButton { get; set; } = true;

		/// <summary>
		/// Set it to false if you want to override the default behavior of the popup closing when another popup is opened.
		/// </summary>
		public bool AutoClose { get; set; } = true;

		/// <summary>
		/// Set it to false if you want to override the default behavior of the ESC key for closing of the popup.
		/// </summary>
		public bool CloseOnEscapeKey { get; set; } = true;

		/// <summary>
		/// The content of the popup.
		/// </summary>
		public string Content { get; set; }

	}
}
