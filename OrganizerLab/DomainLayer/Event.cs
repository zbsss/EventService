using System;
using System.Collections.Generic;

namespace Organizer
{
	public class @Event : Entity
	{
		public string Description { get; protected set; }   // opis wydarzenia
		public string Place { get; protected set; }         // miejsce wydarzenie
		public DateTime Started { get; protected set; }		// czas rozpoczęcia wydarzenia
		public DateTime Completed { get; protected set; }   // czas zakończenia wydarzenia

		// TODO: atrybuty realizujące związki z klasami Alarm, Invitation oraz EventStatus
		private EventStatus status;
		public EventStatus Status {
			get {
				if (DateTime.Now >= Started && DateTime.Now <= Completed)
					status = EventStatus.RUNNING;
				if (DateTime.Now >= Completed)
					status = EventStatus.COMPLETED;
				return status;
			}
		}

		private Alarm alarm;
		private Contact contact;
		private List<Invitation> invitations = new List<Invitation>();
		// ctor
		public Event(string description, string place, DateTime started, DateTime completed)
		{
			if (started > DateTime.Now && completed > DateTime.Now && completed > started)
			{
				Description = description;
				Place = place;
				Started = started;
				Completed = completed;
				status = EventStatus.CREATED;
			}
			else
				throw new ArgumentException("Wrong value of started/completed");
		}

		
		// TODO: implementacja metod
		public void AddSMSAlarm(DateTime dateTime, string phoneNumber, string smsContent)
		{
			 alarm = new SMSAlarm(dateTime, phoneNumber, smsContent);
		}

		internal void ChangeEventDateTime(DateTime start, DateTime end)
		{
			DateTime now3 = DateTime.Now.AddHours(3);
			if (start > now3 && end > now3 && end > start)
			{
				Started = start;
				Completed = end;
				alarm = null; // garbage collector will take care of deletion

				foreach (Invitation invitation in invitations)
				{
					invitation.NotifyParticipant(Description, Place, Started, Completed, Status);
				}
			}
			else
				throw new ArgumentException("Wrong value of start/end");
		}

		public void AddParticipant(Contact contact) 
		{
			var invitation = new Invitation(contact);
			invitations.Add(invitation);
			invitation.NotifyParticipant(Description, Place, Started, Completed, Status);
		}

		public void CancelEvent()
		{
			if (Started > DateTime.Now.AddHours(3))
			{
				status = EventStatus.CANCELED;
				foreach (Invitation invitation in invitations)
				{
					invitation.NotifyParticipant(Description, Place, Started, Completed, Status);
				}
			}
			else
				throw new Exception("To late to cancel event. Can only cancel at least 3h before beginning");
		}

		public void AcceptInvitation(int contactId)
		{
			Invitation invitation = FindInvitation(contactId);
			if (invitation != null)
			{
				invitation.Accept();
			}
		}

		public void RejectInvitation(int contactId)
		{
			Invitation invitation = FindInvitation(contactId);
			if (invitation != null)
			{
				invitation.Reject();
			}
		}


		public Invitation FindInvitation(int contactId)
		{
			foreach (Invitation invitation in invitations)
			{
				if (invitation.ContactId.Equals(contactId))
					return invitation;
			}
			return null;
		}
	}


}


