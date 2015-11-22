using System;

namespace WorkingWithDigits
{
    class Program
    {
        static int countDigits(int n)
        {
            int numOfDigits = 0;
            while (n != 0)
            {
                numOfDigits++;
                n /= 10;
            }
            return numOfDigits;
        }

        static int sumOfDigits(int n)
        {
            int sumOfDigits = 0;
            while (n != 0)
            {
                sumOfDigits += n%10;
                n /= 10;
            }
            return sumOfDigits;
        }

        static int factorialOfDigits(int n)
        {
            int sumOfFactDigits = 0;
            while(n!=0)
            {
                sumOfFactDigits += Factorial(n % 10);
                n /= 10; 
            }
            return sumOfFactDigits;
        }

        static int Factorial(int n)
        {
            if (n == 1)
                return 1;

            return n * Factorial(n - 1);
        }

        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("\nCount of digits: {0}", countDigits(n));
            Console.WriteLine("Sum of digits: {0}", sumOfDigits(n));
            Console.WriteLine("Factorial of sum of digits: {0}", factorialOfDigits(n));
        }
    }
}
