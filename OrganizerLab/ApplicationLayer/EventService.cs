using System;

namespace Organizer
{
	public class EventService
	{
		// TODO: argumenty + imlementacja wszystkich metod

		public int CreateEvent(string description, string place, DateTime start, DateTime stop)
		{
			Event e = new Event(description, place, start, stop);
			EventRepository.AddEvent(e);
			return e.Id;
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
			e.CancelEvent();
		}

		public void ChangeEventDateTime(int eventId, DateTime start, DateTime end)
		{
			var e = EventRepository.Get(eventId);
			e.ChangeEventDateTime(start, end);
		}
	}

}
