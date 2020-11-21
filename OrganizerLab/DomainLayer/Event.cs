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
				Description = description;
				Place = place;
				Started = started;
				Completed = completed;
				status = EventStatus.CREATED;
		}

		
		// TODO: implementacja metod
		public void AddSMSAlarm(DateTime dateTime, string phoneNumber, string smsContent)
		{
			 alarm = new SMSAlarm(dateTime, phoneNumber, smsContent);
		}

		internal void ChangeEventDateTime(DateTime start, DateTime end)
		{
			Started = start;
			Completed = end;
			alarm = null; // garbage collector will take care of deletion

			foreach (Invitation invitation in invitations)
			{
				invitation.NotifyParticipant(Description, Place, Started, Completed, Status);
			}
		}

		public void AddParticipant(Contact contact) 
		{
			var invitation = new Invitation(contact);
			invitations.Add(invitation);
			invitation.NotifyParticipant(Description, Place, Started, Completed, Status);
		}

		public void CancelEvent()
		{
			status = EventStatus.CANCELED;
			foreach(Invitation invitation in invitations)
			{
				invitation.NotifyParticipant(Description, Place, Started, Completed, Status);
			}
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


