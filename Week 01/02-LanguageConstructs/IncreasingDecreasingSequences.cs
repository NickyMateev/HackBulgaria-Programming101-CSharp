using System;

namespace IncreasingDecreasingSequences
{
    class Program
    {
        static bool IsIncreasing(int[] sequence)
        {
            bool isIncreasing = true;
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (sequence[i] >= sequence[i + 1])
                {
                    isIncreasing = false;
                    break;
                }
            }
            return isIncreasing;
        }

        static bool IsDecreasing(int[] sequence)
        {
            bool isDecreasing = true;
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (sequence[i] <= sequence[i + 1])
                {
                    isDecreasing = false;
                    break;
                }
            }
            return isDecreasing;
        }

        static void Main()
        {
            int[] sequence1 = { 1, 2, 3, 4, 2 };
            Console.WriteLine("Is it an increasing sequence -> {0}", IsIncreasing(sequence1));

            int[] sequence2 = { 4, 3, 2 };
            Console.WriteLine("Is it an increasing sequence -> {0}", IsDecreasing(sequence2));
        }
    }
}
