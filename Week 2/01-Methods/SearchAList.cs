using System;
using System.Collections.Generic;

namespace SearchList
{
    class SearchAList
    {
        static bool SearchList(List<string> list, string searched, out int foundIndex)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Contains(searched))
                {
                    foundIndex = i;
                    return true;
                }
            }

            foundIndex = -1;
            return false;
        }

        static void Main()
        {
            List<string> list = new List<string> { "Nicky", "Ivan", "Kolyo", "Nedko", "Petya" };
            string searched = "Nick";
            int foundIndex;

            Console.WriteLine(SearchList(list, searched, out foundIndex));
            Console.WriteLine("Index: " + foundIndex);
        }
    }
}
