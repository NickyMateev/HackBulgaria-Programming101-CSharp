using System;
using System.Collections.Generic;
using System.IO;

namespace BooksAndAuthors
{
    public class CustomAuthorSerializer : IAuthorSerializer
    {
        public Author DeserializeAuthor(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
                return new Author(string.Empty, string.Empty, new List<Book>());
            if (lines.Length == 1)
                return new Author(lines[0], string.Empty, new List<Book>());
            if (lines.Length == 2)
                return new Author(lines[0], lines[1], new List<Book>());

            List<Book> listOfBooks = new List<Book>();

            for (int i = 2; i < lines.Length; i++)
            {
                string[] bookAndDate = lines[i].Split('$');

                if (bookAndDate.Length == 2)
                    listOfBooks.Add(new Book(bookAndDate[0], DateTime.Parse(bookAndDate[1])));
                else
                    throw new ArgumentException("Invalid collection of books!");
            }

            return new Author(lines[0], lines[1], listOfBooks);
        }

        public void SerializeAuthor(Author author, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(author.Name);
                sw.WriteLine(author.Email);
                foreach (var book in author.Books)
                    sw.WriteLine($"{book.Title}${book.PublishDate}");
            }
        }
    }
}