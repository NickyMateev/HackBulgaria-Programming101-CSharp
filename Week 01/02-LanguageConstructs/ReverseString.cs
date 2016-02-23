using System;

namespace ReverseString
{
    class Program
    {
        static string ReverseMe(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static void Main()
        {
            string userInput = "abcdefgh";
            Console.WriteLine("String: {0}", userInput);
            Console.WriteLine("Reversed: {0}", ReverseMe(userInput));
        }
    }
}
