using System;
using System.Text;

namespace SumNumbersInString
{
    class Program
    {
        static int SumOfNumbersInString(string str)
        {
            int sum = 0;
            int currentNum;
            StringBuilder currentString = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '1' && str[i] <= '9')
                {
                    currentString.Append(str[i]);

                    if (i == str.Length - 1) // last iteration
                    {
                        currentNum = int.Parse(currentString.ToString());
                        sum += currentNum;
                    }
                }
                else if (currentString.ToString() == string.Empty)
                {
                    continue;
                }
                else
                {
                    currentNum = int.Parse(currentString.ToString());
                    sum += currentNum;
                    currentString.Clear();
                }
            }
            return sum;
        }

        static void Main()
        {
            string userInput = "1abc33xyz22";
            Console.WriteLine("String: " + userInput);
            Console.WriteLine("Sum of numbers in the string: " + SumOfNumbersInString(userInput));
        }
    }
}
