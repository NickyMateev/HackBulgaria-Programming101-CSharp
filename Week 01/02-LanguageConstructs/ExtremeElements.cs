using System;

namespace ExtremeElements
{
    class Program
    {
        static int Min(int[] items)
        {
            Array.Sort(items);
            return items[0];
        }

        static int Max(int[] items)
        {
            Array.Sort(items);
            return items[items.Length - 1];
        }

        static int NthMin(int n, int[] items)
        {
            if (n > items.Length)
            {
                throw new ArgumentException("ERROR: Not enough elements in the array!");
            }
            Array.Sort(items);
            return items[n - 1];
        }

        static int NthMax(int n, int[] items)
        {
            if (n > items.Length)
            {
                throw new ArgumentException("ERROR: Not enough elements in the array!");
            }
            Array.Sort(items);
            return items[items.Length - n];
        }

        static void Main()
        {
            int[] arr = { 5, 3, 2, 6, 1, 10, -4 };
            Console.Write("Array: ");
            for (int i = 0; i < arr.Length; i++)    // print out array elements
            {
                if (i == arr.Length - 1)
                    Console.Write(arr[i]);
                else
                    Console.Write(arr[i] + ", ");
            }
            Console.WriteLine("\n\nMin element: {0}", Min(arr));
            Console.WriteLine("Max element: {0}", Max(arr));

            Console.WriteLine("3rd Min element: {0}", NthMin(3, arr));
            Console.WriteLine("2nd Max element: {0}", NthMax(2, arr));
        }
    }
}
