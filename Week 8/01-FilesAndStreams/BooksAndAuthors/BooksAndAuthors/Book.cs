using System;

namespace BooksAndAuthors
{
    [Serializable]
    public class Book
    {
        public Book()
        {

        }

        public Book(string title, DateTime publishDate)
        {
            Title = title;
            PublishDate = publishDate;
        }

        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
