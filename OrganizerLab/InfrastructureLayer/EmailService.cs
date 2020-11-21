using System;
using System.Collections.Generic;

namespace Organizer
{
	public class EmailService
	{
		public static void SendEmail(string email, string content)
		{
			Console.WriteLine("Wysyłanie emaila do {0}", email);
			Console.WriteLine("Treść emaila:\n{0}", content);
		}
	}
}

