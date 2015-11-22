using System;
using System.Text;

namespace Anagram
{
    class Program
    {
        static string Alphabetize(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }

        static bool Anagram(string A, string B)
        {
            bool isAnagram = false;

            // string formating
            A = A.ToLower();
            B = B.ToLower();

            A = Alphabetize(A);
            B = Alphabetize(B);

            if (B.Contains(A) == false)
                isAnagram = false;
            else
                isAnagram = true;

            return isAnagram;
        }

        static bool HasAnagramOf(string A, string B)
        {
            bool hasAnagram = false;

            A = A.Replace(" ", "");
            StringBuilder currentSequence = new StringBuilder();

            for (int i = 0; i < B.Length - A.Length; i++)
            {
                for (int j = i; j < i + A.Length; j++)
                {
                    currentSequence.Append(B[j]);
                }

                if (Anagram(A, currentSequence.ToString()))
                {
                    hasAnagram = true;
                    break;
                }
                else
                    currentSequence.Clear();
            }

            return hasAnagram;
        }

        static void Main()
        {
            Console.Write("First string: ");
            string firstString = Console.ReadLine();
            Console.Write("Second string: ");
            string secondString = Console.ReadLine();
            Console.WriteLine("Is the first string an anagram of the second one? -> " + Anagram(firstString, secondString));

            Console.Write("\nEnter another string: ");
            firstString = Console.ReadLine();
            Console.WriteLine("And another one(longer than the previous one): ");
            secondString = Console.ReadLine();
            Console.WriteLine("Is there an anagram of the first string in the second one? -> " + HasAnagramOf(firstString, secondString));

        }
    }
}