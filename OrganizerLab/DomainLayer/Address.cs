using System;

namespace Organizer
{
	public class Address
	{
		public string Street { get; protected set; }			// ulica
		public string HouseNumber { get; protected set; }		// numer domu
		public string ApartmentNumber { get; protected set; }	// numer mieszkania
		public string City { get; protected set; }				// miasto
		public string PostalCode { get; protected set; }		// kod pocztowy

		// ctor
		public Address(string street, string houseNumber, string apartmentNumber, string city, string postalCode)
		{
			Street = street;
			HouseNumber = houseNumber;
			ApartmentNumber = apartmentNumber;
			City = city;
			PostalCode = postalCode;
		}
	}
}


