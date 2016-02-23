using System.IO;
using System.Xml.Serialization;

namespace BooksAndAuthors
{
    public class XMLAuthorSerializer : IAuthorSerializer
    {
        public Author DeserializeAuthor(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Author));
                return (Author)xmlSerializer.Deserialize(sr);
            }
        }

        public void SerializeAuthor(Author author, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Author));
                xmlSerializer.Serialize(sw, author);
            }
        }
    }
}