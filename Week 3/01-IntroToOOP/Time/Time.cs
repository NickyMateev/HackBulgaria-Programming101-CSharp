using System;

namespace Time
{
    class Time
    {
        public DateTime userDate;
            
        public Time(DateTime date)
        {
            userDate = date;
        }

        public override string ToString()
        {
            string date = string.Format("{0:hh:mm:ss dd.MM.yy}", userDate);
            return date;
        }

        public static Time Now()
        {
            Time date = new Time(DateTime.Now);
            return date;
        }
    }
}