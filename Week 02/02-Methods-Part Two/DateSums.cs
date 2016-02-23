using System;
using System.Globalization;

namespace Date_Sums
{
    class DateSums
    {
        static int SumDigits(int number)
        {
            int sum = 0;
            while(number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        static void PrintDatesWithGivenSum(int year, int sum)
        {
            DateTime startDate = DateTime.Parse("01 01 " + year.ToString(), new CultureInfo("en-US"));
            DateTime endDate = DateTime.Parse("12 31 " + year.ToString(), new CultureInfo("en-US"));

            int currentSum = 0;

            while(startDate != endDate)
            {
                currentSum = SumDigits(startDate.Day) + SumDigits(startDate.Month) + SumDigits(startDate.Year);
                if (currentSum == sum)
                {
                    Console.WriteLine("{0:dd MM yyyy}", startDate);
                }
                startDate = startDate.AddDays(1);
            }
        }

        static void Main()
        {
            int year = 2015;
            int sum = 16;

            PrintDatesWithGivenSum(year, sum);
        }
    }
}