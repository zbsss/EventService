using System;

namespace Organizer
{
	public class Contact : Entity
	{
		public string FirstName { get; protected set; }
		public string Surname { get; protected set; }
		public string Description { get; protected set; }
		public string Email { get; protected set; }
		public string Phone { get; protected set; }

		// atrybuty realizujące związki z klasą Address
		public Address Work { get; protected set; }
		public Address Home { get; protected set; }

		// ctor
		public Contact(string firstName, string surname, string description, string email, string phone)
		{
			FirstName = firstName;
			Surname = surname;
			Description = description;
			Email = email;
			Phone = phone;
		}

		public void AddHouseAddress(string street, string houseNumber, string apartmentNumber, string city, string postalCode)
		{
			Home = new Address(street, houseNumber, apartmentNumber, city, postalCode);
		}

		public void AddWorkAddress(string street, string houseNumber, string apartmentNumber, string city, string postalCode)
		{
			Work = new Address(street, houseNumber, apartmentNumber, city, postalCode);
		}
	}
		
}


