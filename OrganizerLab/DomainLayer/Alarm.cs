using System;

namespace Organizer
{
    public abstract class Alarm
    {
        // data i czas alarmu
        public DateTime DateTime { get; protected set; }    

        // ctor
        public Alarm(DateTime dateTime)
        {
            DateTime = dateTime;
        }
    }
}


