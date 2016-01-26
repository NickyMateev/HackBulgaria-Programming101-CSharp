using System;
using System.Collections.Generic;
using Array_Extension;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            List<string> listOfStrings = new List<string>() { "car", "boat", "bike", "truck", "plane", "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ"};
            string result = ArrayExtension.Join(listOfStrings);
            Console.WriteLine(result);
        }
    }
}
