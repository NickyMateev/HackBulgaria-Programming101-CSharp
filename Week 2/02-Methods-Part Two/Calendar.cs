using System;
using System.Globalization;

namespace Calendar
{
    class Calendar
    {
        static void PrintCalendar(int month, int year, CultureInfo culture)
        {
            DateTime currentMonth = new DateTime(year, month, 1);
            DateTime nextMonth = currentMonth.AddMonths(1);

            Console.WriteLine(currentMonth.ToString("MMMM"));

            for (int i = 0; i < 7; i++)
            {
                Console.Write(currentMonth.ToString("dddd").PadLeft(10));
                currentMonth = currentMonth.AddDays(1);
            }
            Console.WriteLine();

            currentMonth = currentMonth.Subtract(new TimeSpan(7, 0, 0, 0)); // substacting the 7 days we added above


            for (; currentMonth < nextMonth; currentMonth = currentMonth.AddDays(1))
            {
                if (currentMonth.Day % 7 == 0)
                {
                    Console.Write(currentMonth.Day.ToString().PadLeft(10));
                    Console.WriteLine();
                }
                else
                    Console.Write(currentMonth.Day.ToString().PadLeft(10));
            }
            Console.WriteLine();
        }

        static void Main()
        {
            int month = 11;
            int year = 2015;
            CultureInfo culture = new CultureInfo("en-US");
            
            PrintCalendar(month, year, culture);
        }
    }
}