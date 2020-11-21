using System;

namespace Organizer
{
	public class InvitationService
	{
		// TODO: argumenty + imlementacja wszystkich metod

		public void AcceptInvitation(int eventId, int contactId)
		{
			Event e = EventRepository.Get(eventId);
			e.AcceptInvitation(contactId);
		}

		public void RejectInvitation(int eventId, int contactId)
		{
			Event e = EventRepository.Get(eventId);
			e.AcceptInvitation(contactId);
		}
	}
}


