using System;
using System.Collections.Generic;
using System.IO;

namespace File_Names_Histogram
{
    class Program
    {
        static Dictionary<string, int> filesAndOccurences = new Dictionary<string, int>();

        static void GetAllFilesInDir(string path)
        {
            DirectoryInfo curDir = new DirectoryInfo(path);

            FileInfo[] filesInDir = curDir.GetFiles();

            string curFile = string.Empty;
            foreach (var file in filesInDir)
            {
                curFile = file.Name.Replace(file.Extension, string.Empty);

                if (filesAndOccurences.ContainsKey(curFile))
                    filesAndOccurences[curFile]++;
                else
                    filesAndOccurences.Add(curFile, 1);
            }

            DirectoryInfo[] subDirectories = curDir.GetDirectories();
            foreach (var dir in subDirectories)
                GetAllFilesInDir(dir.FullName);

        }

        static void Main()
        {
            string path = @"C:\Users\Nicky\Desktop\Directory\";
            
            DirectoryInfo dir = new DirectoryInfo(path);
            GetAllFilesInDir(path);

            Console.WriteLine("Files in the directory: {0}\n", dir.FullName);
            foreach (var item in filesAndOccurences)
                Console.WriteLine("{0} - {1} occurences", item.Key, item.Value);

        }
    }
}