using System;

namespace Organizer
{
	// stany dla klasy Event - zob. diagram stanu
	public enum EventStatus
	{
		// utworzono wydarzenie 
		CREATED,

		// wydarzenie trwa
		RUNNING,

		// wydarzenie zakończone
		COMPLETED,

		// wydarzenie anulowane
		CANCELED
	}
}



