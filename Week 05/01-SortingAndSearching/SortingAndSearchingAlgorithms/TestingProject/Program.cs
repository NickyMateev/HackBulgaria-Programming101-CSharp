using System;
using System.Collections.Generic;
using SortingAndSearching;

namespace TestingProject
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[] { 2, 4, 1, 6, 10 };
            int[] sortedArray = (int[])array.BubbleSort(new MyIntComparer());
            foreach (var item in sortedArray)
                Console.WriteLine(item);
            Console.WriteLine();

            List<int> list = new List<int> { 5, 2, 1, 72, 12, 34, 11 };
            list.SelectionSort(new MyIntComparer());
            list.ForEach(Console.WriteLine);
            Console.WriteLine();

            string str1 = "abc";
            string str2 = null;
            var stringComparer = new StringLengthComparer();
            if (stringComparer.Compare(str1, str2) > 0)
                Console.WriteLine("The first string is longer than the second string.");
            else if (stringComparer.Compare(str1, str2) == 0)
                Console.WriteLine("The string are equal.");
            else
                Console.WriteLine("The first string is shorter than the second string");

            int? first = 12;
            int? second = 7;
            OddEvenComparer comparer = new OddEvenComparer();
            Console.WriteLine(comparer.Compare(first, second));
            Console.WriteLine();

            var list2 = new List<int>() { 1, 6, 12, 123, 343, 564, 1243 };
            Console.WriteLine(list2.BSearch(1243, new MyIntComparer()));
        }
    }
}