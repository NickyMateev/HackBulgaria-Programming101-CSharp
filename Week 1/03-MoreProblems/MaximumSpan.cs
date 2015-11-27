using System;
using System.Collections.Generic;

namespace MaxSpan
{
    class MaximumSpan
    {
        static int MaxSpan(List<int> numbers)
        {
            if (numbers.Count < 2)
                return 1;

            int left = 0;
            int right = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[0] == numbers[numbers.Count - 1 - i])
                {
                    left = numbers.Count - i;
                    break;
                }
                else if (numbers[numbers.Count - 1] == numbers[i])
                {
                    right = numbers.Count - i;
                    break;
                }
            }

            if (left >= right)
                return left;
            else
                return right;
        }

        static void Main()
        {
            List<int> numbers = new List<int> { 1, 4, 2, 1, 4, 1, 4 };
            Console.WriteLine("The max span in this list is: " + MaxSpan(numbers));
        }
    }
}
