using System;

namespace Organizer
{
    public class AlarmClock : Alarm
    {
        // nazwa pliku z dżwiękowego do odtworzenia podczas alarmu
        public string Melody { get; protected set; }

        // ctor
        public AlarmClock(DateTime dateTime, string melody)
            : base(dateTime)
        {
            Melody = melody;
        }
    }
}

