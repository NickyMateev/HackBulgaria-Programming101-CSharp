using System;
using System.Text;

namespace CopyEveryCharacter
{
    class Program
    {
        static string CopyEveryChar(string input, int k)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                result.Append(input[i], k);
            }
            return result.ToString();
        }

        static void Main()
        {
            Console.Write("Enter a string: ");
            string userInput = Console.ReadLine();
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine("\nResult: " + CopyEveryChar(userInput, k));
        }
    }
}
