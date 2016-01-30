using System;
using System.IO;

namespace Simple_file_editor
{
    class Program
    {
        static void ListFileContents(string path)
        {
            Console.WriteLine(File.ReadAllText(path));
        }

        static void ClearFileContents(string path)
        {
            File.WriteAllText(path, string.Empty);
        }

        static void AppendLine(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(sw.NewLine);
            }
        }

        static void AppendText(string path, string textToAppend)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(textToAppend);
            }
        }

        static void LineCount(string path)
        {
            int counter = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.ReadLine() != null)
                    counter++;
            }

            Console.WriteLine("Number of lines: {0}", counter);
        }

        static bool CheckCommand(string userInput, string command)  // method which checks if the userInput corresponds to the given command
        {
            return (userInput.Contains(command) && (userInput.Length == command.Length || userInput[command.Length] == ' '));
        }

        static void PrintHelp()
        {
            Console.Write(new string('-', Console.WindowWidth));
            Console.WriteLine("list - lists the contents of the file");
            Console.WriteLine("clear - clears the contents of the file");
            Console.WriteLine("appendline - appends a new line to the file");
            Console.WriteLine("append <text> - appends the text to the file");
            Console.WriteLine("linecount - outputs the numbers of lines in the file");
            Console.WriteLine("help - prints the full list of commands");
            Console.WriteLine("exit - exits the application");
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the path of the file to edit: ");
            string path = Console.ReadLine();

            if (!File.Exists(path))
                throw new FileNotFoundException("Missing file.");

            Console.WriteLine();
            bool closeApp = false;
            string userInput = string.Empty;

            while(!closeApp)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();
                while (userInput[0] == ' ')
                    userInput = userInput.Remove(0,1);

                Console.ForegroundColor = ConsoleColor.Cyan;
                if (CheckCommand(userInput, "list"))
                    ListFileContents(path);

                else if (CheckCommand(userInput, "clear"))
                    ClearFileContents(path);

                else if (CheckCommand(userInput, "appendline"))
                    AppendLine(path);

                else if (CheckCommand(userInput, "append"))
                    AppendText(path, userInput.Substring(7));   // Everything from the 7th index to the end of the string has to be appended

                else if (CheckCommand(userInput, "linecount"))
                    LineCount(path);

                else if (CheckCommand(userInput, "help"))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    PrintHelp();
                }

                else if (CheckCommand(userInput, "exit"))
                    closeApp = true;

                else
                    Console.WriteLine("Invalid command!");

                Console.WriteLine();
            }


        }
    }
}