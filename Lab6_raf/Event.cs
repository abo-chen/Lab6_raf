using System;
namespace Lab6_raf
{
    [Serializable]
    public class Event
	{
		private int _eventNumber;
		private string _location;

		public int EventNumber { get { return _eventNumber; } }
		public string Location { get { return _location; } }

		public Event() { }

		public Event(int eventNumber, string location)
		{
			_eventNumber = eventNumber;
			_location = location;
		}
	}
}

