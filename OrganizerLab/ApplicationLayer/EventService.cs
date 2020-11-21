using System;

namespace Organizer
{
	public class EventService
	{
		// TODO: argumenty + imlementacja wszystkich metod

		public int CreateEvent(string description, string place, DateTime start, DateTime stop)
		{
			if(start > DateTime.Now && stop > DateTime.Now && stop > start) {
				Event e = new Event(description, place, start, stop);
				EventRepository.AddEvent(e);
				return e.Id;
			}

			throw new ArgumentException("Wrong value of start/stop");
		}

		public void AddSMSAlarm(int eventId,DateTime dateTime,string phoneNumber,string smsContent)
		{
			Event e = EventRepository.Get(eventId);
			e.AddSMSAlarm(dateTime, phoneNumber, smsContent);
		}

		public void AddClockAlarm()
		{
			throw new NotImplementedException();
		}

		public void AddParticipant(int eventId, int contactId)
		{
			Event e = EventRepository.Get(eventId);
			Contact c = ContactRepository.Get(contactId);
			e.AddParticipant(c);
		}

		public void CancelEvent(int eventId)
		{
			var e = EventRepository.Get(eventId);
			if(e.Started > DateTime.Now.AddHours(3))
				e.CancelEvent();
			else
				throw new Exception("To late to cancel event. Can only cancel at least 3h before beginning");
		}

		public void ChangeEventDateTime(int eventId, DateTime start, DateTime end)
		{
			var e = EventRepository.Get(eventId);

			DateTime now3 = DateTime.Now.AddHours(3);
			if (start > now3 && end > now3 && end > start)
				e.ChangeEventDateTime(start, end);
			else
				throw new ArgumentException("Wrong value of start/end");
		}
	}

}
