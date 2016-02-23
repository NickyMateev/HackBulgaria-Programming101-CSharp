using System;

namespace Consonants_in_a_string
{
    class Program
    {
        static int countConsonants(string userInput)
        {
            userInput = userInput.ToLower();
            string consonants = "bcdfghjklmnpqrstvwxz";
            int consonantsCount = 0;
            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < consonants.Length; j++)
                {
                    if (userInput[i] == consonants[j])
                    {
                        consonantsCount++;
                        break;
                    }
                }
            }
            return consonantsCount;
        }

        static void Main()
        {
            string userInput = Console.ReadLine();
            Console.WriteLine("Consonants count: {0}", countConsonants(userInput));
        }
    }
}
