using System.Collections.Generic;

namespace Reverse_String
{
    class ReverseString
    {
        static void ReverseList(List<int> list)
        {
            for (int i = 0; i < list.Count / 2; i++)
            {
                int temp = list[i];
                list[i] = list[list.Count - 1 - i];
                list[list.Count - 1 - i] = temp;
            }
        }

        static void Main()
        {
            List<int> list = new List<int> { 1, 7, 33, -3, 5 };
            ReverseList(list);
        }
    }
}
