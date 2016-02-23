using System;

namespace Fractions
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be 0");
            else
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
        }

        public int Numerator
        {
            get
            {
                return this.numerator;
            }
            set
            {
                this.numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                if (value != 0)
                    this.denominator = value;
                else
                    throw new ArgumentException("Denominator cannot be 0");
            }
        }

        public override string ToString()
        {
            return this.numerator + "/" + this.denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction)
            {
                Fraction obj1 = this;
                Fraction obj2 = (Fraction)obj;

                if (obj1.numerator == obj2.numerator && obj1.denominator == obj2.denominator)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator ==(Fraction fract1, Fraction fract2)
        {
            return fract1.Equals(fract2);
        }

        public static bool operator !=(Fraction fract1, Fraction fract2)
        {
            return !(fract1.Equals(fract2));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + numerator.GetHashCode();
                hash = hash * 23 + denominator.GetHashCode();
                return hash;
            }
        }

        public Fraction Simplify()
        {
            for (int i = 2; i <= (numerator < denominator ? numerator : denominator);)
            {
                if (numerator % i == 0 && denominator % i == 0)
                {
                    numerator /= i;
                    denominator /= i;
                }
                else
                    i++;
            }

            return new Fraction(numerator, denominator);
        }

        public static Fraction operator +(Fraction fract1, Fraction fract2)
        {
            int newNumerator;
            int newDenominator;

            if (fract1.denominator == fract2.denominator)
            {
                newNumerator = fract1.numerator + fract2.numerator;
                newDenominator = fract1.denominator;
            }
            else
            {
                newNumerator = fract1.numerator * fract2.denominator + fract2.numerator * fract1.denominator;
                newDenominator = fract1.denominator * fract2.denominator;
            }

            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public static Fraction operator -(Fraction fract1, Fraction fract2)
        {
            int newNumerator;
            int newDenominator;

            if (fract1.denominator == fract2.denominator)
            {
                newNumerator = fract1.numerator - fract2.numerator;
                newDenominator = fract1.denominator;
            }
            else
            {
                newNumerator = fract1.numerator * fract2.denominator - fract2.numerator * fract1.denominator;
                newDenominator = fract1.denominator * fract2.denominator;
            }

            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public static Fraction operator *(Fraction fract1, Fraction fract2)
        {
            int newNumerator = fract1.numerator * fract2.numerator;
            int newDenominator = fract1.denominator * fract2.denominator;

            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public static Fraction operator /(Fraction fract1, Fraction fract2)
        {
            int newNumerator = fract1.numerator * fract2.denominator;
            int newDenominator = fract1.denominator * fract2.numerator;

            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public static double operator +(Fraction fract, double number)
        {
            return (double)fract + number;
        }

        public static double operator +(double number, Fraction fract)
        {
            return number + (double)fract;
        }

        public static double operator -(Fraction fract, double number)
        {
            return (double)fract - number;
        }

        public static double operator -(double number, Fraction fract)
        {
            return number - (double)fract;
        }

        public static double operator *(Fraction fract, double number)
        {
            return (double)fract * number;
        }

        public static double operator *(double number, Fraction fract)
        {
            return number * (double)fract;
        }

        public static double operator /(Fraction fract, double number)
        {
            return (double)fract / number;
        }

        public static double operator /(double number, Fraction fract)
        {
            return number / (double)fract;
        }

        public static explicit operator double(Fraction fract)
        {
            return (double)fract.numerator / (double)fract.denominator;
        }
    }
}