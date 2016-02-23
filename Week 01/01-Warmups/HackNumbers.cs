using System;
using System.Text;

namespace Hack_Numbers
{
    class Program
    {
        static string DecimalToBinary(int n)
        {
            string binary = "";
            while(n != 0)
            {
                binary += n % 2;
                n /= 2;
            }
            binary = Reverse(binary);
            return binary;
        }

        static string Reverse(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static bool isHack(int n)
        {
            string binary = DecimalToBinary(n);
            
            int countOf1s = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    countOf1s++;
                }
            }

            if (countOf1s % 2 == 1 && isBinaryPalindrome(binary))
                return true;
            else
                return false;
        }

        static int nextHack(int n)
        {
            n++;
            while(isHack(n) == false)
            {
                n++;
            }
            return n;
        }

        static bool isBinaryPalindrome(string binary)
        {
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();

            if (binary.Length % 2 == 1)   // odd number of digits
            {
                for (int i = 0; i < binary.Length / 2; i++)
                    str1.Append(binary[i]);

                for (int i = binary.Length - 1; i > binary.Length / 2; i--)
                    str2.Append(binary[i]);
            }
            else  // even number of digits
            {
                for (int i = 0; i < binary.Length / 2; i++)
                    str1.Append(binary[i]);

                for (int i = binary.Length - 1; i >= binary.Length / 2; i--)
                    str2.Append(binary[i]);
            }

            if (str1.ToString() == str2.ToString())
                return true;
            else
                return false;
        }

        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("isHack -> {0}\n", isHack(n));

            Console.Write("m = ");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Next hack number -> {0}", nextHack(m));
        }
    }
}
