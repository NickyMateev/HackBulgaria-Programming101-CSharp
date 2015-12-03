using System;

namespace Clock_Angle
{
    class ClockAngle
    {
        static double GetClockHandsAngle(DateTime time, bool isExact)
        {
            double angle = -1;
            double hoursDegree = -1;
            double minutesDegree = -1;

            if (time.Hour >= 12)
                time.Subtract(new TimeSpan(12, 00, 00));

            if (isExact)
            {
                hoursDegree = time.Hour * 30;
                minutesDegree = time.Minute * 6;
                angle = Math.Abs(hoursDegree - minutesDegree);
            }
            else
            {
                hoursDegree = (time.Hour * 60 + time.Minute) * 0.5;
                minutesDegree = time.Minute * 6;
                angle = Math.Abs(hoursDegree - minutesDegree);
            }
            return angle;
        }

        static void Main()
        {
            DateTime userTime = new DateTime(2015, 08, 15, 04, 34, 00);
            double angle = GetClockHandsAngle(userTime, true);
            Console.WriteLine("{0}\nAngle between the clock hands: {1} degrees", userTime, angle);
        }
    }
}