using System;

namespace BlazorLeaflet.Exceptions
{
	/// <summary>
	/// Exception thrown when the user tried to manipulate the map before it has been initialized.
	/// </summary>
	public class UninitializedMapException : Exception
	{

		public UninitializedMapException()
		{

		}

		public UninitializedMapException(string message) : base(message)
		{

		}

	}
}