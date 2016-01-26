using System;
using System.Collections.Generic;
using SortingBooksMagazines;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            List<Book> books = new List<Book>() { new Book("Steve Jobs: The Book", 4613), new Book("Bill Gates: The Book", 6253) };
            List<Magazine> magazines = new List<Magazine>() { new Magazine("Forbes", 2564), new Magazine("Time", 5653) };

            foreach (var item in MagazineAndBookSorter.Sort(books, magazines))
            {
                Console.WriteLine(item);
            }
        }
    }
}
