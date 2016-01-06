using System;
using GameLibrary;
using System.Threading;

namespace TheGame
{
    class Game
    {
        static void Main()
        {
            string mapPath = @"C:\Users\Nicky\Desktop\level1.txt";
            Dungeon dungeon = new Dungeon(mapPath);
            Hero hero = new Hero("Bron", "Dragonslayer", 40, 100, 2);
            hero.Equip(new Weapon("Axe of Destiny", 40));
            dungeon.Spawn(hero);


            while(!dungeon.LevelCompleted && dungeon.CanRespawn)
            {
                Console.SetCursorPosition(0, 0);
                dungeon.PrintMap();
                Console.WriteLine("Game feed: ");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.UpArrow)    // Up Arrow -> Go Up
                        dungeon.MoveHero(Direction.Up);
                    if (userInput.Key == ConsoleKey.DownArrow)  // Down Arrow -> Go Down
                        dungeon.MoveHero(Direction.Down);
                    if (userInput.Key == ConsoleKey.LeftArrow)  // Left Arrow -> Go Left
                        dungeon.MoveHero(Direction.Left);
                    if (userInput.Key == ConsoleKey.RightArrow) // Right Arrow -> Go Right
                        dungeon.MoveHero(Direction.Right);
                    if (userInput.Key == ConsoleKey.Spacebar)   // Space Bar -> Attack (if hero is in sufficient range)
                        dungeon.HeroAttack();
                }

                Thread.Sleep(100);
            };

            Console.ForegroundColor = ConsoleColor.Red;
            if (dungeon.LevelCompleted)
                Console.WriteLine("You win!");
            else
                Console.WriteLine("You lose!");
            
        }
    }
}