using System;
using System.Collections.Generic;

namespace Aggregates
{
    public delegate T AggregationDelegate<T>(T x, T y);

    class Aggregate
    {
        static int Max(int x, int y)
        {
            return x > y ? x : y;
        }

        static T AggregationCollection<T>(List<T> original, AggregationDelegate<T> aggregation)
        {
            T result = original[0];
            for (int i = 1; i < original.Count; i++)
            {
                result = aggregation(result, original[i]);
            }

            return result;
        }

        static void Main()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            Console.Write("List: ");
            foreach (var item in list)
                Console.Write(item + " ");
            
            Console.WriteLine("\nMax: " + AggregationCollection(list, Max));
        }
    }
}