using System;

namespace _1337
{
    class Program
    {
        static void HackerTime()
        {
            DateTime currentTime = DateTime.Now;
            DateTime targetDate = new DateTime(currentTime.Year, 12, 21, 13, 37, 00);

            if (currentTime > targetDate)
                targetDate = targetDate.AddYears(1);
            
            TimeSpan span = targetDate - currentTime;
            Console.WriteLine("{0:dd\\:hh\\:mm}", span);
        }

        static void Main()
        {
            HackerTime();
        }
    }
}
