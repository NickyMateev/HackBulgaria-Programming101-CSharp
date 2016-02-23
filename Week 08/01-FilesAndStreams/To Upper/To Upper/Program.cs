using System.Collections.Generic;
using System.IO;

namespace To_Upper
{
    class Program
    {
        static void Main()
        {
            string filePath = @"C:\Users\Nicky\Desktop\textFile.txt";
            List<string> lines = new List<string>();

            string curLine = string.Empty;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while((curLine = sr.ReadLine()) != null)
                {
                    lines.Add(curLine.ToUpper());   
                }
            }

            string newFilePath = @"C:\Users\Nicky\Desktop\newTextFile.txt";
            using (StreamWriter sw = new StreamWriter(newFilePath))
            {
                foreach (var line in lines)
                    sw.WriteLine(line);
            }

        }
    }
}