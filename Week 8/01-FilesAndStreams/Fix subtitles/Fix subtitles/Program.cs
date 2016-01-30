using System;
using System.Text;
using System.IO;

namespace Fix_subtitles
{
    class Program
    {
        static void FixEncoding(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("ERROR: File does not exists at the specified path: {0}", path);

            FileStream fs;  // the try-catch block is used so that we can ensure the file is valid and there's no problem reading from it
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            catch (Exception exception)
            {
                Console.WriteLine("An unexpected error occurred!");
                Console.WriteLine(exception.Message);
                return;
            }

            fs.Close();

            string newFilePath = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + "-EDITED" + Path.GetExtension(path));

            string textFromFile = File.ReadAllText(path, Encoding.GetEncoding(1251));

            File.WriteAllText(newFilePath, textFromFile, Encoding.UTF8);
        }

        static void Main()
        {
            string path = @"C:\Users\Nicky\Desktop\subtitlesFolder\subtitles.srt";
            FixEncoding(path);
        }
    }
}