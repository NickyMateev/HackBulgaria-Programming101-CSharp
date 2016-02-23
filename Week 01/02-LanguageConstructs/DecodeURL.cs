using System;
using System.Text;

namespace DecodeURL
{
    class Program
    {
        static string DecodeURL(string input)
        {
            StringBuilder url = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (i >= input.Length - 2)  // if there are less than three symbols left, there is no point in checking for decoding
                {
                    url.Append(input[i]);
                    continue;
                }

                if (input[i] == '%')
                {
                    if (input[i + 1] == '2')
                    {
                        if (input[i + 2] == '0')    // %20
                        {
                            url.Append(' ');
                            i += 2;
                            continue;
                        }
                        else if (input[i + 2] == 'F')   //%2F
                        {
                            url.Append('/');
                            i += 2;
                            continue;
                        }
                    }
                    else if (input[i + 1] == '3')
                    {
                        if (input[i + 2] == 'A')    //%3A
                        {
                            url.Append(':');
                            i += 2;
                            continue;
                        }
                        else if (input[i + 2] == 'D')   //%3D
                        {
                            url.Append('?');
                            i += 2;
                            continue;
                        }
                    }
                }

                url.Append(input[i]);   // otherwise, append the current symbol
            }
            return url.ToString();
        }

        static void Main()
        {
            string userInput = "kitten%20pic.jpg";
            Console.WriteLine("Input: " + userInput);
            Console.WriteLine("Output: " + DecodeURL(userInput));
        }
    }
}
