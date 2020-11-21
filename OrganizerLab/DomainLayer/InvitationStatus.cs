using System;

namespace Organizer
{
	// stany dla klasy Invitation - zob. diagram stanu
	public enum InvitationStatus
	{
		// utworzono zaproszenie
		CREATED,

		// zaproszenie zaakceptowane przez uczestnika
		ACCEPTED,

		// zaproszenie odrzucone przez uczestnika
		REJECTED
	}
}



