using System;

namespace Vector
{
    class VectorProblem
    {
        static void Main()
        {
            Vector vect1 = new Vector(1, 3, 5, 10);
            Console.WriteLine(vect1.ToString());
            Vector vect2 = vect1 + 5;
            Console.WriteLine(vect2.ToString());
            Vector vect3 = vect1 * vect2;
            Console.WriteLine(vect3.ToString());
        }
    }
}
