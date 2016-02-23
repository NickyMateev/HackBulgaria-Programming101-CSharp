using System;
using System.Collections.Generic;

namespace Transversal
{
    class Transversal
    {
        static bool IsTransversal(List<int> set, List<List<int>> family)
        {
            bool[] flagArray = new bool[family.Count];

            for (int i = 0; i < set.Count; i++)
            {
                for (int j = 0; j < family.Count; j++)
                {
                    foreach (var element in family[j])
                    {
                        if (element == set[i])
                        {
                            flagArray[j] = true;
                            break;
                        }
                    }
                }
            }

            foreach (var flag in flagArray)
            {
                if (flag == false)
                    return false;
            }
            return true;    // otherwise the set is transversal for the family
        }
        
        static void Main()
        {
            List<List<int>> family = new List<List<int>> {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 },
                new List<int> { 7, 8, 9 }
            };

            List<int> set = new List<int> { 1, 4, 7 };
            Console.WriteLine(IsTransversal(set, family));
        }
    }
}
