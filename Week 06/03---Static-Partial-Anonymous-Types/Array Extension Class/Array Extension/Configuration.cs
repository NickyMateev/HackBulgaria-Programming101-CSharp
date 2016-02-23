using System;

namespace Array_Extension
{
    public class Configuration
    {
        public char GetReplacingValue()
        {
            int resultNum = 0;
            DateTime date = DateTime.Now;
            resultNum += GetSumOfDigits(date.Day);
            resultNum += GetSumOfDigits(date.Month);
            resultNum += GetSumOfDigits(date.Year);
            resultNum += GetSumOfDigits(date.Hour);
            resultNum += GetSumOfDigits(date.Minute);
            resultNum += GetSumOfDigits(date.Second);

            resultNum = resultNum % 25;
            resultNum += 65;

            return (char)resultNum;
        }

        private int GetSumOfDigits(int num)
        {
            int sum = 0;

            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

    }
}