using System;
using System.Text;

namespace Integer_palindromes
{
    class Program
    {
        static bool isIntPalindrome(int N)
        {
            string numToString = N.ToString();
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();

            if (numToString.Length % 2 == 1)   // odd number of digits
            {
                for (int i = 0; i < numToString.Length / 2; i++)
                    str1.Append(numToString[i]);

                for (int i = numToString.Length - 1; i > numToString.Length / 2; i--)
                    str2.Append(numToString[i]);
            }
            else  // even number of digits
            {
                for (int i = 0; i < numToString.Length / 2; i++)
                    str1.Append(numToString[i]);

                for (int i = numToString.Length - 1; i >= numToString.Length / 2; i--)
                    str2.Append(numToString[i]);
            }

            if (str1.ToString() == str2.ToString())
                return true;
            else
                return false;
        }

        static int getLargestPalindrome(int N)
        {
            N--;
            while(isIntPalindrome(N) == false)
            {
                N--;
            }
            return N;
        }

        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Is it a palindrome -> {0}", isIntPalindrome(n));

            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Result: {0}", getLargestPalindrome(N));
        }
    }
}
