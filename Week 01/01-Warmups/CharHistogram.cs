using System;
using System.Collections.Generic;

namespace Char_Histogram
{
    class Program
    {
        
        static Dictionary<char, int> CharHistogram(string userInput)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < userInput.Length; i++)
            {
                if (dict.ContainsKey(userInput[i]) == true)
                {
                    dict[userInput[i]]++;
                }
                else
                {
                    dict.Add(userInput[i], 1);
                }
            }

            return dict;
        }

        static void Main()
        {
            Console.Write("Enter a string: ");
            string userInput = Console.ReadLine();
            Dictionary<char, int> charHistogram = CharHistogram(userInput);

            foreach (var pair in charHistogram)
            {
                Console.WriteLine("'{0}' : {1}", pair.Key, pair.Value);
            }

        }
    }
}
