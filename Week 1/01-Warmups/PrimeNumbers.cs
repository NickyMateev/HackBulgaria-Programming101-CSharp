using System;

namespace Prime_Numbers
{
    class Program
    {
        static bool isPrime(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        static void ListFirstPrimes(int n)
        {
            int counter = 0;
            int currentNum = 2;
            while (counter != n)
            {
                if (isPrime(currentNum))
                {
                    Console.WriteLine(currentNum);
                    counter++;
                }
                currentNum++;
            }
        }

        static void SieveOfEratosthenes(int n)
        {
            int k = 100000; // random large number
            bool[] arrayOfNumbers = new bool[k];

            for (int i = 2; i < arrayOfNumbers.Length; i++)
            {
                arrayOfNumbers[i] = true;
            }

            for (int i = 2; i < k; i++)
            {
                if (arrayOfNumbers[i] == true)
                {
                    for (int j = 2; i*j < k; j++)
                    {
                        arrayOfNumbers[i * j] = false;
                    }
                }
            }

            int counter = 0;
            for (int i = 0; i < k; i++)
            {   
                if (arrayOfNumbers[i] == true)
                {
                    Console.WriteLine(i);
                    counter++;
                }

                if (counter == n)
                    break;
            }
        }

        static void Main()
        {
            Console.Write("Enter a number: ");
            int userInput = int.Parse(Console.ReadLine());
            Console.WriteLine("Is prime? -> " + isPrime(userInput));

            Console.Write("\nList the first n prime numbers:\nn = ");
            int n = int.Parse(Console.ReadLine());
            ListFirstPrimes(n);

            Console.Write("\nList the first n prime numbers using the Sieve of Eratosthenes:\nn = ");
            n = int.Parse(Console.ReadLine());
            SieveOfEratosthenes(n);
        }
    }
}
