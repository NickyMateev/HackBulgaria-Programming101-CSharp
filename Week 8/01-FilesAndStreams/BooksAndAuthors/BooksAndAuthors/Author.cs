using System;
using System.Collections.Generic;

namespace BooksAndAuthors
{
    [Serializable]
    public class Author
    {
        public Author()
        {

        }

        public Author(string name, string email, List<Book> listOfBooks)
        {
            Name = name;
            Email = email;
            Books = listOfBooks;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> Books { get; set; }
    }
}
