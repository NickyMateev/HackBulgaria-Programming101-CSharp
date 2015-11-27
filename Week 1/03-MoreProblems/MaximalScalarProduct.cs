using System;
using System.Collections.Generic;

namespace MaximalScalarProduct
{
    class MaximalScalarProduct
    {
        static int MaxScalarProduct(List<int> v1, List<int> v2)
        {
            v1.Sort();
            v2.Sort();

            List<int> newList = new List<int>();
            for (int i = 0; i < v1.Count; i++)
                newList.Add(v1[i] * v2[i]);

            int scalarProduct = 0;
            foreach (var item in newList)
                scalarProduct += item;

            return scalarProduct;
        }


        static void Main()
        {
            List<int> v1 = new List<int> { 7, 2, 5, 3, 13 };
            List<int> v2 = new List<int> { 3, 11, 2, 6, 5 };

            Console.WriteLine("Largest possible scalar product: " + MaxScalarProduct(v1, v2));
        }
    }
}
