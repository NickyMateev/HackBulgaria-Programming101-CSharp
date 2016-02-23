using System;

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

            A = A.Replace(" ", "");
            B = B.Replace(" ", "");

            // check the string lengths
            if (A.Length != B.Length)
            {
                isAnagram = false;
                return isAnagram;
            }

            A = Alphabetize(A);
            B = Alphabetize(B);

            if (A.Contains(B) == false)
                isAnagram = false;
            else
                isAnagram = true;

            return isAnagram;
        }

        static void Main()
        {
            string firstString = "B a N";
            string secondString = "Ab N";

            Console.WriteLine("Result: " + Anagram(firstString, secondString));
            
        }
    }
}
