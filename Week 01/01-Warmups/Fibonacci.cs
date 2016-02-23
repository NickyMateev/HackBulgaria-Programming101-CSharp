using System;

namespace Fibonacci_Number
{
    class Program
    {
        static int Fibonacci(int n)
        {
            if (n < 1)
                throw new ArgumentException("ERROR: Input must be larger than 0!");
            if (n == 1)
                return 1;
            if (n == 2)
                return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int m = 1;
            string concatenation = "";

            while(m <= n)
            {
                concatenation += Fibonacci(m);
                m++;
            }

            Console.WriteLine("fibNumber({0}) = {1}", n, concatenation);
        }
    }
}
