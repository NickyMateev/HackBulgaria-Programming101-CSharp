using System;
using System.Text;

namespace JoiningStrings
{
    class JoiningStrings
    {
        static string JoinStrings(string seperator, params string[] strings)
        {
            StringBuilder joinedString = new StringBuilder();
            for (int i = 0; i < strings.Length; i++)
            {
                if (i != strings.Length - 1)
                    joinedString.Append(strings[i] + seperator);
                else
                    joinedString.Append(strings[i]);
            }
            return joinedString.ToString();
        }

        static void Main()
        {
            string str = JoinStrings(", ", "One", "Two", "Three", "Four", "Five");
            Console.WriteLine(str);
        }
    }
}
