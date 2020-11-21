using System;
using System.Collections.Generic;

namespace Organizer
{
	public class ContactRepository
	{
		private static Dictionary<int, Contact> idToContact = new Dictionary<int, Contact>();
		public static void Add(Contact c)
		{
			idToContact.Add(c.Id, c);
		}
		public static Contact Get(int contatcId)
		{
			return idToContact[contatcId];
		}
	}
}