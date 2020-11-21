using System;

namespace Organizer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // utworzyć 2 kontakty z adresami
                ContactService contactService = new ContactService();

                int id1 = contactService.CreateContact("Jan", "Kowalski", "janek", "kowal@poczta.fm.pl", "122345674");
                contactService.AddHouseAddress(id1, "Mickiewicza", "12", null, "Kraków", "30-383");
                contactService.AddWorkAddress(id1, "Lea", "113", "12", "Kraków", "30-343");

                int id2 = contactService.CreateContact("Jan", "Nowak", "janek nowak", "nowak@poczta.onet.pl", "225435674");
                contactService.AddHouseAddress(id2, "Krupnicza", "9", "3", "Kraków", "22-433");
                contactService.AddWorkAddress(id2, "Grodzka", "4a", "3", "Kraków", "30-343");


                // utworzyć wydarzenie z alarmem
                EventService eventService = new EventService();

                int id3 = eventService.CreateEvent("Kolokwium ćwiczenia", "sala 207", new DateTime(2021, 6, 11, 15, 0, 0), new DateTime(2021, 6, 11, 16, 30, 0));
                eventService.AddSMSAlarm(id3, new DateTime(2020, 6, 4, 15, 0, 0), "+48792223344", "Wstawaj kolokwium");

                // do wydarzenia dodać 2 uczestników
                eventService.AddParticipant(id3, id1);
                eventService.AddParticipant(id3, id2);

                // jeden uczestnik potwierdza uczestnictwo, drugi odwoluje
                InvitationService invitationService = new InvitationService();
                invitationService.AcceptInvitation(id3, id1);
                invitationService.RejectInvitation(id3, id2);

                // zmieniono termin wydarzenia
                //eventService.ChangeEventDateTime(id3, new DateTime(2022, 6, 11, 15, 0, 0), new DateTime(2022, 6, 11, 16, 30, 0));

                // wydarzenie jest odwolane przez własciciela organizatora
                eventService.CancelEvent(id3);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("\nNie wszystkie klasy zostały zaimplementowane!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nWystąpił błąd w trakcie wykonywania programu!");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
