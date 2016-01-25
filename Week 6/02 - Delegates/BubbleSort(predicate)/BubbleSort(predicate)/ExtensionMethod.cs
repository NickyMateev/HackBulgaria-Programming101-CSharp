using System.Collections.Generic;

namespace BubbleSort_predicate_
{
    public delegate bool ComparerDelegate(int x, int y);

    public static class ExtensionMethod
    {

        public static bool Compare(int x, int y)
        {
            return (x - y) > 0;
        }

        public static IList<int> BubbleSort(this IList<int> list, ComparerDelegate comparer)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (comparer(list[j], list[j + 1]))
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            return list;
        }

    }
}