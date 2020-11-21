using System;
using System.Collections.Generic;

namespace Organizer
{
	public class EventRepository
	{
		private static Dictionary<int, Event> idToEvent = new  Dictionary<int,Event>();
		public static void AddEvent(Event e)
		{
			idToEvent.Add(e.Id,e);
		}
		public static Event  Get(int eventId)
		{
			return idToEvent[eventId];
		}
	}
}

