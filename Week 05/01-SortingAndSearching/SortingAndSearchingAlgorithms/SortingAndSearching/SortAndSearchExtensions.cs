using System.Collections.Generic;

namespace SortingAndSearching
{
    public static class SortAndSearchExtensions 
    {
        public static IList<T> BubbleSort<T>(this IList<T> list)
        {
            return list.BubbleSort(Comparer<T>.Default);
        }

        public static IList<T> BubbleSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (comparer.Compare(list[j], list[j + 1]) > 0)
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            return list;
        }
        
        public static IList<T> SelectionSort<T>(this IList<T> list)
        {
            return list.SelectionSort(Comparer<T>.Default);
        }

        public static IList<T> SelectionSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            int minIndex;
            for (int i = 0; i < list.Count - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (comparer.Compare(list[j], list[minIndex]) < 0)
                        minIndex = j;
                }

                if (minIndex != i)
                {
                    T temp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = temp;
                }
            }

            return list;
        }

        public static int BSearch<T>(this IList<T> list, T value)
        {
            return list.BSearch(value, Comparer<T>.Default);
        }

        public static int BSearch<T>(this IList<T> list, T value, IComparer<T> comparer)
        {
            int min = 0;
            int max = list.Count - 1;

            int mid;
            while (min <= max)
            {
                mid = (min + max) / 2;
                if (comparer.Compare(value, list[mid]) == 0)
                    return mid;
                else if (comparer.Compare(value, list[mid]) < 0)
                    max = mid - 1;
                else    // comparer.Compare(value, list[mid]) > 0
                    min = mid + 1;
            }

            return -1;  // if the element is not found in the collection => return -1
        }

    }
}