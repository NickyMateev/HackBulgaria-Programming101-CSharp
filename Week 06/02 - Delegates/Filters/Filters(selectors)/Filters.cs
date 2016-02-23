using System;
using System.Collections.Generic;

namespace Filters_selectors_
{
    public delegate bool FilterDelegate<T>(T number);

    class Filters
    {
        public static bool PositiveNumber(int number)
        {
            return number >= 0;
        }

        static List<T> FilterCollection<T>(List<T> original, FilterDelegate<T> filter)
        {
            List<T> filteredList = new List<T>();

            for (int i = 0; i < original.Count; i++)
            {
                if (filter(original[i]))
                    filteredList.Add(original[i]);
            }

            return filteredList;
        }
        
        static void Main()
        {
            List<int> list = new List<int>() { 3, 6, 1, -2, -6, 34 };
            List<int> filteredList = FilterCollection(list, PositiveNumber);

            Console.Write("Original list: ");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }

            Console.Write("\nPositive numbers: ");
            foreach (var item in filteredList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }
    }
}