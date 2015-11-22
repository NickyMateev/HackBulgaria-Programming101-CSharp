using System;
using System.Text;

namespace Palindrome_score
{
    class Program
    {
        static string Reverse(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

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

        static int PScore(int n)
        {
            if (isIntPalindrome(n))
            {
                return 1;
            }
            else
            {
                string reversed = n.ToString();
                reversed = Reverse(reversed);
                int newInt = n + int.Parse(reversed);
                return 1 + PScore(newInt); 
            }
        }

        static void Main()
        {
            Console.Write("Find out the Palindrome score of: ");
            int userInput = int.Parse(Console.ReadLine());
            Console.WriteLine("\nPScore({0}) = {1}", userInput, PScore(userInput));
        }
    }
}
