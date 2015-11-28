using System;
using System.Collections.Generic;
using System.IO;

namespace Directory_traversal
{
    class DirectoryTraversal
    {
        static IEnumerable<string> IterateDirectory(DirectoryInfo dir)
        {
            foreach (var file in dir.GetFiles("*", SearchOption.AllDirectories))
            {
                yield return file.FullName;
            }
        }

        static void Main()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Nicky\Desktop\Directory");
            string str = string.Join(Environment.NewLine, IterateDirectory(dir));
            Console.WriteLine(str);
        }
    }
}
