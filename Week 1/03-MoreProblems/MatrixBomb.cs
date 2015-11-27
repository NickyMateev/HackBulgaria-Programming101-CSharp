using System;

namespace Matrix_Bombing
{
    class MatrixBomb
    {
        static int GetDmg(int substraction, params int[] neighbours)
        {
            int dmg = 0;
            foreach (var neighbour in neighbours)
            {
                if (substraction > neighbour)
                    dmg += neighbour;
                else
                    dmg += substraction;
            }
            return dmg;
        }

        static int MatrixBombing(int[,] m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);

            int maxDamage = 0;
            int currentDamge = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == 0)
                    {
                        if (col == 0)
                            currentDamge = GetDmg(m[row, col], m[row, col + 1], m[row + 1, col], m[row + 1, col + 1]);

                        else if (col == cols - 1)
                            currentDamge = GetDmg(m[row, col], m[row, col - 1], m[row + 1, col - 1], m[row + 1, col]);

                        else // col is somewhere in between
                            currentDamge = GetDmg(m[row, col], m[row, col - 1], m[row, col + 1], m[row + 1, col - 1], m[row + 1, col], m[row + 1, col + 1]);
                    }
                    else if (row == rows - 1)
                    {
                        if (col == 0)
                            currentDamge = GetDmg(m[row, col], m[row - 1, col], m[row - 1, col + 1], m[row, col + 1]);

                        else if (col == cols - 1)
                            currentDamge = GetDmg(m[row, col], m[row, col - 1], m[row - 1, col - 1], m[row - 1, col]);

                        else // col is somewhere in between
                            currentDamge = GetDmg(m[row, col], m[row, col - 1], m[row, col + 1], m[row - 1, col - 1], m[row - 1, col], m[row - 1, col + 1]);

                    }
                    else if (col == 0)
                        currentDamge = GetDmg(m[row, col], m[row - 1, col], m[row + 1, col], m[row - 1, col + 1], m[row, col + 1], m[row + 1, col + 1]);

                    else if (col == cols - 1)
                        currentDamge = GetDmg(m[row, col], m[row - 1, col], m[row + 1, col], m[row - 1, col - 1], m[row, col - 1], m[row + 1, col - 1]);
                    else // otherwise we're somewhere in the mid (not on the sides or corners)
                        currentDamge = GetDmg(m[row, col], m[row - 1, col - 1], m[row - 1, col], m[row - 1, col + 1], m[row, col - 1], m[row, col + 1], m[row + 1, col - 1], m[row + 1, col], m[row + 1, col + 1]);

                    if (currentDamge > maxDamage)
                        maxDamage = currentDamge;
                }
            }

            return maxDamage;
        }

        static void Main()
        {
            int[,] matrix = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            Console.WriteLine("Maximum possible damage: " + MatrixBombing(matrix));
        }
    }
}
