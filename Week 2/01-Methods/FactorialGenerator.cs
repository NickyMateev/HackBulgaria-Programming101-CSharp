using System;
using System.Collections.Generic;

namespace Factorial_generator
{
    class FactorialGenerator
    {
        static IEnumerable<int> GenerateFactorials(int n)
        {
            int factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
                yield return factorial;
            }
        }


        static void Main()
        {
            int n = 5;
            string factorials = string.Join("  ", GenerateFactorials(n));
            Console.WriteLine(factorials);
        }
    }
}
