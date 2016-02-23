using System;

namespace Fractions
{
    class FractionsProblem
    {
        static void Main()
        {
            Fraction fract = new Fraction(2, 7);
            Console.WriteLine(fract + 3 / 4.0);

            Fraction fract2 = new Fraction(2, 4);
            Fraction product = fract * fract2;
            Console.WriteLine(product);
        }
    }
}
