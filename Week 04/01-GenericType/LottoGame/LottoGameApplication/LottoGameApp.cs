using System;
using Lotto_Game;

namespace LottoGameApplication
{
    class LottoGameApp
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("How many combinations will you enter: ");
            int numberOfCombinations = int.Parse(Console.ReadLine());
            Console.WriteLine("\nA combination is comprised of 6 values. The first three values should share the same C# type(this should be the case with the second three values as well).\n");

            Combination<int, string> winningCombination = new Combination<int, string>(new int[] { 1, 2, 3 }, new string[] { "pesho", "gosho", "ivan" });
            LottoGame<int, string> lottoGame = new LottoGame<int, string>(winningCombination);

            Console.ForegroundColor = ConsoleColor.Cyan;
            int count = 1;
            while(count <= numberOfCombinations)
            {
                Console.Write("Combination {0}:\n", count);
                Console.Write("\tValue 1(int): ");
                int value1 = int.Parse(Console.ReadLine());
                Console.Write("\tValue 2(int): ");
                int value2 = int.Parse(Console.ReadLine());
                Console.Write("\tValue 3(int): ");
                int value3 = int.Parse(Console.ReadLine());
                Console.Write("\tValue 4(string): ");
                string value4 = Console.ReadLine();
                Console.Write("\tValue 5(string): ");
                string value5 = Console.ReadLine();
                Console.Write("\tValue 6(string): ");
                string value6 = Console.ReadLine();

                Combination<int, string> currentComb = new Combination<int, string>(new int[] { value1, value2, value3}, new string[] { value4, value5, value6});

                if(lottoGame.CheckIfExists(currentComb))
                {
                    Console.WriteLine("The current combination has already been entered! Try again.");
                    continue;
                }
                else
                {
                    lottoGame.AddUserCombination(currentComb);
                }
                Console.WriteLine();

                count++;
            }

            LottoResult<int, string> lottoResult = lottoGame.Validate();
            if (lottoResult.IsWinning)
                Console.WriteLine("Congratulations! Your best combination has {0} matching values!", lottoResult.MatchedNumbersCount);
            else
                Console.WriteLine("Unfortunately there are no winning combinations among the ones given.");

        }
    }
}