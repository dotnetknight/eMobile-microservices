using System;

namespace Common.Events
{
    public abstract class Event
    {
        public DateTime TimeStamp { get; set; }

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
