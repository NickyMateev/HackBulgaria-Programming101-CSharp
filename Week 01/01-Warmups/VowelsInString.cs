using System;

namespace Vowels_in_a_string
{
    class Program
    {
        static int countVowels(string userInput)
        {
            userInput = userInput.ToLower();
            int vowelCount = 0;
            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] == 'a' || userInput[i] == 'e' || userInput[i] == 'i' || userInput[i] == 'o' || userInput[i] == 'u' || userInput[i] == 'y')
                {
                    vowelCount++;
                }
            }
            return vowelCount;
        }

        
        static void Main()
        {
            string userInput = Console.ReadLine();
            Console.WriteLine("Vowel count: {0}", countVowels(userInput));
        }
    }
}
