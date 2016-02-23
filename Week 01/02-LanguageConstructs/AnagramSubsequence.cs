using System;
using System.Text;

namespace IsAnagram
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

            for (int i = 0; i <= B.Length - A.Length; i++)
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
            string firstString = "R I a";
            string secondString = "Air travel can be expensive sometimes.";

            Console.WriteLine("Result: " + HasAnagramOf(firstString, secondString));
        }
    }
}