using System.IO;

namespace Directory_Copy
{
    class Program
    {
        static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if(!dir.Exists)
                throw new DirectoryNotFoundException(string.Format("Given directory does not exist: {0}", dir.FullName));
            
            if (!Directory.Exists(destDirName))
                Directory.CreateDirectory(destDirName);

            FileInfo[] files = dir.GetFiles();
            foreach (var file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            if(copySubDirs)
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (var subDir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subDir.Name);
                    DirectoryCopy(subDir.FullName, tempPath, copySubDirs);
                }

            }

        }

        static void Main()
        {
            string path = @"C:\Users\Nicky\Desktop\Directory";
            string destPath = @"C:\Users\Nicky\Desktop\testDir\testFolder\";
            DirectoryCopy(path, destPath, true);
        }
    }
}