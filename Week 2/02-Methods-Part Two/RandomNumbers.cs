using System;
using System.IO;

namespace Random_Numbers
{
    class RandomNumbers
    {
        static Random rand = new Random();

        static void GenerateRandomMatrix(int rows, int cols, string fileName)
        {
            string stringMatrix = "";
            double[,] matrix = new double[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rand.Next(0, 100000) / 100.00;
                    stringMatrix += String.Format("{0,8:F2} ", matrix[row, col]);
                }
                stringMatrix += Environment.NewLine;
            }
            File.WriteAllText(@"C:\Users\Nicky\Desktop\" + fileName, stringMatrix);
        }

        static void Main()
        {
            string fileName = "randomNumbers.txt";
            Console.Write("rows = ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("cols = ");
            int cols = int.Parse(Console.ReadLine());

            Console.WriteLine("\nGenerating random numbers to a file...");
            GenerateRandomMatrix(rows, cols, fileName);
            Console.WriteLine("Done.");
        }
    }
}