using System;
using System.Data;

namespace Organizer
{
	public class ContactService
	{
		public int CreateContact(string firstName, string surname, string description, string email, string phone)
		{
			if (String.IsNullOrEmpty(firstName) && String.IsNullOrEmpty(surname) && String.IsNullOrEmpty(description) && String.IsNullOrEmpty(email) && String.IsNullOrEmpty(phone))
				throw new ArgumentNullException("Aby utworzyć nowy kontakt przynajmniej jeden element z kontaktu musi posiadać dane");

			var contact = new Contact(firstName, surname, description, email, phone);
			ContactRepository.Add(contact);
			Console.WriteLine($"Utworzono kontakt '{firstName} {surname}' id = {contact.Id}");
			return contact.Id;
		}

		public void AddHouseAddress(int contactId, string street, string houseNumber, string apartmentNumber, string city, string postalCode)
		{
			if (String.IsNullOrEmpty(street) && String.IsNullOrEmpty(houseNumber) && String.IsNullOrEmpty(apartmentNumber) && String.IsNullOrEmpty(city) && String.IsNullOrEmpty(postalCode))
				throw new ArgumentNullException("Aby dodać adres domowy do kontaktu przynajmniej jeden element z adresu musi posiadać dane");

			var contact = ContactRepository.Get(contactId)
				?? throw new ArgumentNullException($"Brak kontaktu id = {contactId}");

			contact.AddHouseAddress(street, houseNumber, apartmentNumber, city, postalCode);
			Console.WriteLine($"Kontaktowi id = {contactId} przypisano adres domowy");
		}

		public void AddWorkAddress(int contactId, string street, string houseNumber, string apartmentNumber, string city, string postalCode)
		{
			if (String.IsNullOrEmpty(street) && String.IsNullOrEmpty(houseNumber) && String.IsNullOrEmpty(apartmentNumber) && String.IsNullOrEmpty(city) && String.IsNullOrEmpty(postalCode))
				throw new ArgumentNullException("Aby dodać adres miejsc pracy do kontaktu przynajmniej jeden element z adresu musi posiadać dane");

			var contact = ContactRepository.Get(contactId)
				?? throw new ArgumentNullException($"Brak kontaktu id = {contactId}");

			contact.AddWorkAddress(street, houseNumber, apartmentNumber, city, postalCode);
			Console.WriteLine($"Kontaktowi id = {contactId} przypisano adres miejsca pracy");
		}
	}
}


