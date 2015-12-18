using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linked_List;

namespace ConsoleApplication
{
    class Program
    {
        static void Main()
        {
            Linked_List.LinkedList<string> list = new Linked_List.LinkedList<string>();
            list.Add("x");
            list.Add("g");
            list.Add("s");

            Console.WriteLine(list.Count); //output: 3

            list.InsertAfter("g", "a");
            // list.InsertAt(10, "z"); //throws an exception - IndexOutOfRangeException
            list.InsertAt(2, "z");
            list.Remove("z");
            list[1] = "m";
            
            Console.WriteLine();



            foreach (string value in list)
            {
                Console.WriteLine(value);
            }
            //output:
            //x
            //m
            //a
            //s
        }
    }
}
