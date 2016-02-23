namespace BooksAndAuthors
{
    public interface IAuthorSerializer
    {
        void SerializeAuthor(Author author, string filePath);

        Author DeserializeAuthor(string filePath);
    }
}