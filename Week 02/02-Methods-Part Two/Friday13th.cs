using System;
using System.Globalization;

namespace Friday13th
{
    class Friday13th
    {
        static int UnfortunateFridays(DateTime startYear, DateTime endYear)
        {
            int counter = 0;

            while (startYear != endYear)
            {
                if (startYear.Day == 13)
                {
                    if (startYear.ToString("dddd") == "Friday")
                    {
                        counter++;
                    }
                }
                startYear = startYear.AddDays(1);
            }
            return counter;
        }

        static void Main()
        {
            DateTime startDate = DateTime.Parse("01 01 2015", new CultureInfo("en-US"));
            DateTime endDate = DateTime.Parse("12 31 2015", new CultureInfo("en-US"));

            int counter = UnfortunateFridays(startDate, endDate);
            Console.WriteLine("Result: {0}", counter);
        }
    }
}
