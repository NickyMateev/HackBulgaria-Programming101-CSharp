using System.Collections.Generic;
using System.Text;

namespace NumberList
{
    class Program
    {
        static List<int> NumberToList(int n)
        {
            List<int> list = new List<int>();
            while (n != 0)
            {
                list.Add(n % 10);
                n /= 10;
            }
            return list;
        }

        static int ListToNumber(List<int> digits)
        {
            StringBuilder integer = new StringBuilder();
            foreach (var element in digits)
            {
                integer.Append(element);
            }
            int number = int.Parse(integer.ToString());
            return number;
        }

        static void Main()
        {
            int n = 123;
            List<int> list = NumberToList(n);
            list.Reverse();

            List<int> list2 = new List<int> { 4, 5, 6};
            int numberFromList = ListToNumber(list2);
        }
    }
}
