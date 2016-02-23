using System;

namespace ReverseEachWord
{
    class Program
    {
        static string ReverseMe(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static string ReverseEveryWord(string str)
        {
            string[] stringArray = str.Split(' ');

            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = ReverseMe(stringArray[i]);
            }

            string result = string.Join(" ", stringArray);

            return result;
        }

        static void Main()
        {
            string str = "Petya smokes a ton of cigarettes.";
            Console.WriteLine(str);
            Console.WriteLine(ReverseEveryWord(str));
        }
    }
}
