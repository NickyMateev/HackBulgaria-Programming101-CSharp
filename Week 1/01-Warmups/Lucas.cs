using System;

namespace Lucas_series
{
    class Program
    {
        static int nthLucas(int n)
        {
            if (n == 0)
                return 2;
            if (n == 1)
                return 1;

            return nthLucas(n - 1) + nthLucas(n - 2);
        }

        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(nthLucas(n));
        }
    }
}
