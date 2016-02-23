using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Array_Extension
{
    public static class ArrayExtension 
    {
        private static readonly char ReplacingValue;

        static ArrayExtension()
        {
            ReplacingValue = new Configuration().GetReplacingValue();
        }

        public static List<T> Intersect<T>(this List<T> firstList, List<T> secondList) where T : IComparable
        {
            List<T> newList = new List<T>();

            foreach (var item in firstList)
            {
                if (secondList.Contains(item))
                    newList.Add(item);
            }

            return newList;
        }

        public static List<T> UnionAll<T>(List<T> firstList, List<T> secondList) where T : IComparable
        {
            List<T> newList = new List<T>();
            newList.AddRange(firstList);
            newList.AddRange(secondList);

            return newList;
        }

        public static List<T> Union<T>(List<T> firstList, List<T> secondList) where T : IComparable
        {
            List<T> newList = new List<T>();
            newList.AddRange(firstList);

            foreach (var item in secondList)
            {
                if (newList.Contains(item) == false)
                    newList.Add(item);
            }

            return newList;
        }

        public static string Join(List<string> list)
        {
            StringBuilder resultString = new StringBuilder();

            foreach (var item in list)
                if (item.Contains(ReplacingValue))
                    resultString.Append(item);

            return resultString.ToString();
        }

    }
}