using System;

namespace Organizer
{
	public class SMSAlarm : Alarm
	{
		public string PhoneNumber { get; protected set; }   // numer telefonu na który należy wysłać alarm SMS
		public string SmsContent { get; protected set; }    // treść sms-a z alarmem

		public SMSAlarm(DateTime dateTime, string phoneNumber, string smsContent)
			: base(dateTime)
		{
			PhoneNumber = phoneNumber;
			SmsContent = smsContent;
		}
	}
}


