using System.Collections.Generic;
using System.Linq;

namespace SortingBooksMagazines
{
    public static class MagazineAndBookSorter
    {
        public static List<string> Sort(List<Book> books, List<Magazine> magazines)
        {
            List<Edition> collection = new List<Edition>();

            foreach (var book in books)
                collection.Add(new Edition(book));

            foreach (var magazine in magazines)
                collection.Add(new Edition(magazine));

            return collection
                .OrderBy(x => x.EditionName)
                .ThenBy(x => x.Order)
                .Select(x => x.EditionName)
                .ToList();
        }

        public class Edition
        {
            public string EditionName { get; }
            public int Order { get; }

            public Edition(Book book)
            {
                EditionName = book.Name;
                Order = book.Id;
            }

            public Edition(Magazine magazine)
            {
                EditionName = magazine.Title;
                Order = magazine.ISBN;
            }
        }
    }
}