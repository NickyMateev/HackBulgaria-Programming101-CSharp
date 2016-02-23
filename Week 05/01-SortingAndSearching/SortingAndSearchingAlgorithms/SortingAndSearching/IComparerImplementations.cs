using System.Collections.Generic;

namespace SortingAndSearching
{
    /* all implementations of IComparer return a negative number if firstNumber is less than secondNumber,
     0 if firstNumber is equal to secondNumber,
     and a positive number if firstNumber is greater than secondNumber
    */

    public class MyIntComparer : IComparer<int>
    {
        public int Compare(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }

    public class LastDigitComparer : IComparer<int>
    {
        public int Compare(int firstNumber, int secondNumber)
        {
            return (firstNumber % 10) - (secondNumber % 10);
        }
    }

    public class StringLengthComparer : IComparer<string>
    {
        public int Compare(string firstString, string secondString)
        {
            if (firstString == null && secondString == null)
                return 0;

            else if (firstString == null)
                return 0 - secondString.Length;

            else if (secondString == null)
                return firstString.Length - 0;

            else
                return firstString.Length - secondString.Length;
        }
    }

    public class OddEvenComparer : IComparer<int?>
    {
        public int Compare(int? firstNumber, int? secondNumber)
        {
            if (firstNumber % 2 == 0 && secondNumber % 2 == 1)
                return -1;
            else if (firstNumber % 2 == 1 && secondNumber % 2 == 0)
                return 1;
            else if (firstNumber % 2 == 1 && secondNumber % 2 == 1)
                return firstNumber.Value - secondNumber.Value;
            else if (firstNumber % 2 == 0 && secondNumber == 0)
                return secondNumber.Value - firstNumber.Value;
            else
            {
                if (firstNumber == null && secondNumber == null)
                    return 0;
                else if (firstNumber == null)
                    return -1;
                else
                    return 1;
            }
        }
    }

    public class ReverseComparer<T> : IComparer<T>
    {
        public int Compare(T firstNumber, T secondNumber)
        {
            return Comparer<T>.Default.Compare(secondNumber, firstNumber);
        }
    }

}