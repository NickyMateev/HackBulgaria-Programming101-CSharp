using System;
using Pair_Rewritten_;

namespace Program
{
    class Program
    {
        static void Main()
        {
            Pair<int, string> pair1 = new Pair<int, string>(5, "five");
            Pair<int, string> pair2 = new Pair<int, string>(5, "five");
            Console.WriteLine(pair1 == pair2);
        }
    }
}