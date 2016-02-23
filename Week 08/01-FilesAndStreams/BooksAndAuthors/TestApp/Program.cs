using System;
using System.Collections.Generic;
using BooksAndAuthors;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            List<Book> books = new List<Book>()
            {
                new Book("The Power Of Now", new DateTime(1997, 03, 01)),
                new Book("C# for Dummies", new DateTime(2010, 01, 01)),
                new Book("Book: The book", new DateTime(2016, 01, 30))
            };

            Author author = new Author("Peter Parker", "batman@superman.com", books);

            // example #1
            string filePath = @"C:\Users\Nicky\Desktop\author.xml";
            XMLAuthorSerializer serializer = new XMLAuthorSerializer();
            serializer.SerializeAuthor(author, filePath);

            // example #2
            string filePath2 = @"C:\Users\Nicky\Desktop\customAuthor.txt";
            CustomAuthorSerializer customSerializer = new CustomAuthorSerializer();
            customSerializer.SerializeAuthor(author, filePath2);

            // example #3
            string filePath3 = @"C:\Users\Nicky\Desktop\authorToDeserialize.txt";
            Author deserializedAuthor = customSerializer.DeserializeAuthor(filePath3);
            Console.WriteLine(deserializedAuthor.Name);
            Console.WriteLine(deserializedAuthor.Email);
            foreach (var book in deserializedAuthor.Books)
                Console.WriteLine($"{book.Title} - {book.PublishDate}");
        }
    }
}