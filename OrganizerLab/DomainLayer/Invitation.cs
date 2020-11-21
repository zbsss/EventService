using System;
using System.Data;
using System.Text;

namespace Organizer
{
	public class Invitation
	{
		public string FirstName { get; protected set; }		// imię uczestnika wydarzenia
		public string Surname { get; protected set; }       // nazwisko uczestnika wydarzenia
		public string Email { get; protected set; }         // adres email uczestnika wydarzenia

		// atrybut realizujący związek "logiczny" z klasą Contact
		// Związki pomiędzy klasami z różnych agregatów realizujemy w postaci klucza obcego
		public int ContactId { get; protected set; }
		private InvitationStatus invitationStatus;

		// TODO: atrybut realizujący związek z klasą InvitationStatus
	
		public Invitation(Contact contact)
		{
			ContactId = contact.Id;
			FirstName = contact.FirstName;
			Surname = contact.Surname;
			Email = contact.Email;
			invitationStatus = InvitationStatus.CREATED;
		}

		// TODO: implementacja metod
		public void NotifyParticipant(string description, string place, DateTime started, DateTime completed, EventStatus status)
		{
			string content = PrepareNotificationContent(FirstName, Surname, description, place, started, completed, status);
			EmailService.SendEmail(Email, content);
		}

		public string PrepareNotificationContent(string firstName, string surName, string description, string place, DateTime start, DateTime stop, EventStatus status)
		{
			StringBuilder builder = new StringBuilder();
			builder
				.AppendLine("Masz zaproszenie na wydarzenie.")
				.Append("Opis tego wydarzenia:  ").AppendLine(description)
				.Append("Odbędzie się ono: ").Append(start.ToString())
				.Append(", a zakończy sie: ").AppendLine(stop.ToString())
				.Append("w : ").AppendLine(place)
				.Append("Status eventu: ").AppendLine(status.ToString());
			return builder.ToString();
		}

		public void Accept()
		{
			invitationStatus = InvitationStatus.ACCEPTED;
		}

		public void Reject()
		{
			invitationStatus = InvitationStatus.REJECTED;
		}

	}
}



