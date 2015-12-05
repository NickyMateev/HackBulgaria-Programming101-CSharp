using System;

namespace Pair
{
    class PairProblem
    {
        static void Main()
        {
            Pair test = new Pair(1, 3);
            Pair test2 = new Pair(1, 3);
            Console.WriteLine(test.Equals(test2));
        }
    }
}
