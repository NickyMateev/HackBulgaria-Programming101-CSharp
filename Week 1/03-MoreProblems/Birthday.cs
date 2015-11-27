using System;
using System.Collections.Generic;

namespace Birthday_Ranges
{
    class Birthday
    {
        static List<int> BirthdayRanges(List<int> birthdays, List<KeyValuePair<int, int>> ranges)
        {
            List<int> resultList = new List<int>();
            int counter = 0;

            foreach (var pair in ranges)
            {
                counter = 0;
                foreach (var birthday in birthdays)
                {
                    if (pair.Key <= birthday && pair.Value >= birthday)
                    {
                        counter++;
                    }
                }
                resultList.Add(counter);
            }

            return resultList;
        }


        static void Main()
        {
            List<int> birthdays = new List<int> { 5, 10, 6, 7, 3, 4, 5, 11, 21, 300, 15 };
            List<KeyValuePair<int, int>> ranges = new List<KeyValuePair<int, int>>
            {
                new KeyValuePair<int, int> (4, 9),
                new KeyValuePair<int, int> (6, 7),
                new KeyValuePair<int, int> (200, 225),
                new KeyValuePair<int, int> (300, 365)
            };

            List<int> resultList = BirthdayRanges(birthdays, ranges);
            foreach (var item in resultList)
            {
                Console.Write(item + "  ");
            }
        }
    }
}
