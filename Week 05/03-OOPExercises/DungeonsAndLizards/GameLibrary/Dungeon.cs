using System;
using System.Collections.Generic;
using System.IO;

namespace GameLibrary
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Dungeon
    {
        private char[,] map;
        private Hero hero;
        private long heroRow;
        private long heroCol;

        Random rand = new Random(); // we'll use this to randomly pick a treasure in PickTreasure()
        private List<object> listOfTreasure = new List<object>() {
            new Weapon("Big sword", 25),
            new Spell("Arrow of Hope", 50, 20, 2),
            new HealthPotion(30),
            new ManaPotion(40),
            new Weapon("Shield", 40),
            new Spell("Wingardium Leviosa", 20, 30, 1),
            new HealthPotion(50),
            new ManaPotion(60)
            };

        private List<Enemy> listOfEnemiesOnMap = new List<Enemy>();

        public bool LevelCompleted { get; private set; } = false;
        public bool CanRespawn { get; private set; } = true;

        public Dungeon(string mapPath)
        {
            GetMap(mapPath);
        }

        private void GetMap(string mapPath)
        {
            string textFromFile = File.ReadAllText(@mapPath); // @ is there for safety reasons; the program works without the symbol as well
            string[] lines = textFromFile.Split('\n');

            map = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)  // filling out the map with symbols
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                    if (map[i, j] == 'E')   // spawning the enemies on the map
                        listOfEnemiesOnMap.Add(new Enemy(100, 100, 20) { EnemyRow = i, EnemyCol = j}); // could make this better
                }
            }

        }

        public void PrintMap()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row, col] == 'H')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(map[row, col]);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                        Console.Write(map[row, col]);

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
         
        public bool Spawn(Hero hero)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (map[row, col] == 'S')
                    {
                        map[row, col] = 'H';
                        heroRow = row;
                        heroCol = col;
                        this.hero = hero;
                        return true;
                    }
                }
            }

            CanRespawn = false;
            return false;
        }

        private void PickTreasure()
        {
            byte randomNum = (byte)rand.Next(0, listOfTreasure.Count);
            if (listOfTreasure[randomNum] is Weapon)
            {
                hero.Equip((Weapon)listOfTreasure[randomNum]);
                Console.WriteLine("Found {0}({1} dmg). Hero is now equiped with it.", ((Weapon)listOfTreasure[randomNum]).Name, ((Weapon)listOfTreasure[randomNum]).Damage);
            }

            else if (listOfTreasure[randomNum] is Spell)
            {
                hero.Learn((Spell)listOfTreasure[randomNum]);
                Console.WriteLine("Found {0}({1} dmg, {2} mana cost, {3} cast range). Hero can now cast this spell.", ((Spell)listOfTreasure[randomNum]).Name, ((Spell)listOfTreasure[randomNum]).Damage, ((Spell)listOfTreasure[randomNum]).ManaCost, ((Spell)listOfTreasure[randomNum]).CastRange);
            }

            else if (listOfTreasure[randomNum] is HealthPotion)
            {
                hero.TakeHealing(((HealthPotion)listOfTreasure[randomNum]).HealthPoints);
                Console.Write("Found health potion({0}).", ((HealthPotion)listOfTreasure[randomNum]).HealthPoints);
                if (hero.GetHealth() == hero.MaxHealth)
                    Console.WriteLine("Hero health is max({0}).", hero.MaxHealth);
                else
                    Console.WriteLine("Hero health is {0}.", hero.GetHealth());
            }

            else if (listOfTreasure[randomNum] is ManaPotion)
            {
                hero.TakeMana(((ManaPotion)listOfTreasure[randomNum]).ManaPoints);
                Console.Write("Found mana potion({0}).", ((ManaPotion)listOfTreasure[randomNum]).ManaPoints);
                if (hero.GetMana() == hero.MaxMana)
                    Console.WriteLine("Hero mana is max({0}).", hero.MaxMana);
                else
                    Console.WriteLine("Hero mana is {0}.", hero.GetMana());
            }

            else
                throw new ArgumentException("ERROR: Unable to get treasure from the list of treasure!");
        }

        public bool MoveHero(Direction direction)
        {
            hero.TakeMana(hero.ManaRegenerationRate);
            if (direction == Direction.Up)
            {
                if (heroRow - 1 < 0)
                    return false;
                else if (map[heroRow - 1, heroCol] == '#' || map[heroRow - 1, heroCol] == 'S')
                    return false;
                else if (map[heroRow - 1, heroCol] == '.')
                {
                    map[heroRow, heroCol] = '.';
                    map[heroRow - 1, heroCol] = 'H';
                    heroRow--;
                    return true;
                }
                else if (map[heroRow - 1, heroCol] == 'T')
                {
                    PickTreasure();
                    map[heroRow, heroCol] = '.';
                    map[heroRow - 1, heroCol] = 'H';
                    heroRow--;
                    return true;
                }
                else if (map[heroRow - 1, heroCol] == 'E')
                {
                    map[heroRow, heroCol] = '.';
                    heroRow--;

                    foreach (var enemy in listOfEnemiesOnMap)
                    {
                        if (enemy.EnemyRow == heroRow && enemy.EnemyCol == heroCol)
                        {
                            Fight(hero, enemy);
                            if (enemy.GetHealth() == 0)
                            {
                                Console.WriteLine("Enemy is dead.");
                                map[heroRow, heroCol] = 'H';
                                return true;
                            }
                            else if (hero.GetHealth() == 0)
                            {
                                Console.WriteLine("You died.");
                                return Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                            }
                            else
                                throw new ArgumentException("ERROR: Unkown fight outcome!");
                        }
                    }

                    throw new ArgumentException("ERROR: Unkown fight outcome!");
                }

                else if (map[heroRow - 1, heroCol] == 'G')
                {
                    map[heroRow, heroCol] = '.';
                    map[heroRow - 1, heroCol] = 'H';
                    LevelCompleted = true;
                    return true;
                }
                else
                    throw new ArgumentException("ERROR: Unkown symbol on the map!");
            }
            else if (direction == Direction.Down)
            {
                if (heroRow + 1 >= map.GetLength(0) - 1)
                    return false;
                else if (map[heroRow + 1, heroCol] == '#' || map[heroRow + 1, heroCol] == 'S')
                    return false;
                else if (map[heroRow + 1, heroCol] == '.')
                {
                    map[heroRow, heroCol] = '.';
                    map[heroRow + 1, heroCol] = 'H';
                    heroRow++;
                    return true;
                }
                else if (map[heroRow + 1, heroCol] == 'T')
                {
                    PickTreasure();
                    map[heroRow, heroCol] = '.';
                    map[heroRow + 1, heroCol] = 'H';
                    heroRow++;
                    return true;
                }
                else if (map[heroRow + 1, heroCol] == 'E')
                {
                    map[heroRow, heroCol] = '.';
                    heroRow++;

                    foreach (var enemy in listOfEnemiesOnMap)
                    {
                        if (enemy.EnemyRow == heroRow && enemy.EnemyCol == heroCol)
                        {
                            Fight(hero, enemy);
                            if (enemy.GetHealth() == 0)
                            {
                                Console.WriteLine("Enemy is dead.");
                                map[heroRow, heroCol] = 'H';
                                return true;
                            }
                            else if (hero.GetHealth() == 0)
                            {
                                Console.WriteLine("You died.");
                                return Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                            }
                            else
                                throw new ArgumentException("ERROR: Unkown fight outcome!");
                        }
                    }

                    throw new ArgumentException("ERROR: Unkown fight outcome!");
                }

                else if (map[heroRow + 1, heroCol] == 'G')
                {
                    map[heroRow, heroCol] = '.';
                    map[heroRow + 1, heroCol] = 'H';
                    LevelCompleted = true;
                    return true;
                }
                else
                    throw new ArgumentException("ERROR: Unkown symbol on the map!");
            }
            else if (direction == Direction.Left)
            {
                if (heroCol - 1 < 0)
                    return false;
                else if (map[heroRow, heroCol - 1] == '#' || map[heroRow, heroCol - 1] == 'S')
                    return false;
                else if (map[heroRow, heroCol - 1] == '.')
                {
                    map[heroRow, heroCol] = '.';
                    map[heroRow, heroCol - 1] = 'H';
                    heroCol--;
                    return true;
                }
                else if (map[heroRow, heroCol - 1] == 'T')
                {
                    PickTreasure();
                    map[heroRow, heroCol] = '.';
                    map[heroRow, heroCol - 1] = 'H';
                    heroCol--;
                    return true;
                }
                else if (map[heroRow, heroCol - 1] == 'E')
                {
                    map[heroRow, heroCol] = '.';
                    heroCol--;

                    foreach (var enemy in listOfEnemiesOnMap)
                    {
                        if (enemy.EnemyRow == heroRow && enemy.EnemyCol == heroCol)
                        {
                            Fight(hero, enemy);
                            if (enemy.GetHealth() == 0)
                            {
                                Console.WriteLine("Enemy is dead.");
                                map[heroRow, heroCol] = 'H';
                                return true;
                            }
                            else if (hero.GetHealth() == 0)
                            {
                                Console.WriteLine("You died.");
                                return Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                            }
                            else
                                throw new ArgumentException("ERROR: Unkown fight outcome!");
                        }
                    }

                    throw new ArgumentException("ERROR: Unkown fight outcome!");
                }

                else if (map[heroRow, heroCol - 1] == 'G')
                {
                    map[heroRow, heroCol] = '.';
                    map[heroRow, heroCol - 1] = 'H';
                    LevelCompleted = true;
                    return true;
                }
                else
                    throw new ArgumentException("ERROR: Unkown symbol on the map!");
            }
            else if (direction == Direction.Right)
            {
                if (heroCol + 1 >= map.GetLength(1) - 1)
                    return false;
                else if (map[heroRow, heroCol + 1] == '#' || map[heroRow, heroCol + 1] == 'S')
                    return false;
                else if (map[heroRow, heroCol + 1] == '.')
                {
                    map[heroRow, heroCol] = '.';
                    map[heroRow, heroCol + 1] = 'H';
                    heroCol++;
                    return true;
                }
                else if (map[heroRow, heroCol + 1] == 'T')
                {
                    PickTreasure();
                    map[heroRow, heroCol] = '.';
                    map[heroRow, heroCol + 1] = 'H';
                    heroCol++;
                    return true;
                }
                else if (map[heroRow, heroCol + 1] == 'E')
                {
                    map[heroRow, heroCol] = '.';
                    heroCol++;

                    foreach (var enemy in listOfEnemiesOnMap)
                    {
                        if (enemy.EnemyRow == heroRow && enemy.EnemyCol == heroCol)
                        {
                            Fight(hero, enemy);
                            if (enemy.GetHealth() == 0)
                            {
                                Console.WriteLine("Enemy is dead.");
                                map[heroRow, heroCol] = 'H';
                                return true;
                            }
                            else if (hero.GetHealth() == 0)
                            {
                                Console.WriteLine("You died.");
                                return Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                            }
                            else
                                throw new ArgumentException("ERROR: Unkown fight outcome!");
                        }
                    }

                    throw new ArgumentException("ERROR: Unkown fight outcome!");
                }

                else if (map[heroRow, heroCol + 1] == 'G')
                {
                    map[heroRow, heroCol] = '.';
                    map[heroRow, heroCol + 1] = 'H';
                    LevelCompleted = true;
                    return true;
                }
                else
                    throw new ArgumentException("ERROR: Unkown symbol on the map!");
            }
            else
                throw new ArgumentException("ERROR: Invalid direction!");
        }

        public void Fight(Hero hero, Enemy enemy)
        {
            Console.WriteLine("A fight is started between Hero(health={0}, mana={1}) and Enemy(health={2}, mana={3}, damage{4})", hero.GetHealth(), hero.GetMana(), enemy.GetHealth(), enemy.GetMana(), enemy.GetDamage());

            while(enemy.GetHealth() != 0 && hero.GetHealth() != 0)
            {
                // Hero's turn:
                if (hero.IsEquiped && hero.KnowsSpell)
                {
                    if (hero.GetWeapon().Damage > hero.GetSpell().Damage)
                        hero.Attack(hero.GetWeapon(), enemy);
                    else
                    {
                        if (hero.CanCast())  // use spell
                            hero.Attack(hero.GetSpell(), enemy);
                        else  // use weapon
                            hero.Attack(hero.GetWeapon(), enemy);
                    }
                }
                else if (hero.IsEquiped)
                    hero.Attack(hero.GetWeapon(), enemy);
                else if (hero.KnowsSpell)
                {
                    if (hero.CanCast())
                        hero.Attack(hero.GetSpell(), enemy);
                    else
                        Console.WriteLine("Hero hits with bare hands for 0 dmg(no mana). Enemy health is {0}.", enemy.GetHealth());
                }
                else
                    Console.WriteLine("Hero hits with bare hands for 0 dmg(no weapons or spells). Enemy health is {0}.", enemy.GetHealth());

                if (enemy.GetHealth() == 0)
                    break;

                // Enemy's turn:
                if (enemy.EnemyRow == heroRow && enemy.EnemyCol == heroCol) // fight
                {
                    if (enemy.IsEquiped && enemy.KnowsSpell)
                    {
                        if (enemy.GetDamage() >= enemy.GetWeapon().Damage && enemy.GetDamage() >= enemy.GetSpell().Damage)
                            enemy.Attack(hero);
                        else if (enemy.GetWeapon().Damage >= enemy.GetDamage() && enemy.GetWeapon().Damage >= enemy.GetSpell().Damage)
                            enemy.Attack(enemy.GetWeapon(), hero);
                        else if (enemy.GetSpell().Damage >= enemy.GetDamage() && enemy.GetSpell().Damage >= enemy.GetWeapon().Damage)
                        {
                            if (enemy.CanCast())
                                enemy.Attack(enemy.GetSpell(), hero);
                            else if (enemy.GetWeapon().Damage > enemy.GetDamage())
                                enemy.Attack(enemy.GetWeapon(), hero);
                            else
                                enemy.Attack(hero);
                        }
                    }
                    else if (enemy.IsEquiped)
                    {
                        if (enemy.GetWeapon().Damage > enemy.GetDamage())
                            enemy.Attack(enemy.GetWeapon(), hero);
                        else
                            enemy.Attack(hero);
                    }
                    else if (enemy.KnowsSpell)
                    {
                        if (enemy.CanCast())
                            enemy.Attack(enemy.GetSpell(), hero);
                        else
                            enemy.Attack(hero);
                    }
                    else
                        enemy.Attack(hero);
                }
                else  // move
                {
                    if (heroRow == enemy.EnemyRow)
                    {
                        if(enemy.EnemyCol < heroCol)
                        {
                            enemy.EnemyCol++;
                            Console.WriteLine("Enemy moves one square to the right in order to get to the hero. This is his move.");
                        }
                        else
                        {
                            enemy.EnemyCol--;
                            Console.WriteLine("Enemy moves one square to the left in order to get to the hero. This is his move.");
                        }
                    }
                    else if (heroCol == enemy.EnemyCol)
                    {
                        if(enemy.EnemyRow < heroRow)
                        {
                            enemy.EnemyRow++;
                            Console.WriteLine("Enemy moves down one square in order to get to the hero. This is his move.");
                        }
                        else
                        {
                            enemy.EnemyRow--;
                            Console.WriteLine("Enemy moves up one square in order to get to the hero. This is his move.");
                        }
                    }
                    else
                        throw new ArgumentException("ERROR: A problem occured when trying to move the enemy!");
                }

                hero.TakeMana(hero.ManaRegenerationRate);
            }   
        }

        public void HeroAttack()
        {
            if (hero.GetWeapon() != null || hero.GetSpell() != null)
            {
                if (hero.GetWeapon() != null && hero.GetSpell() == null) // hero only has a weapon
                {
                    HeroAttackByWeapon();
                }
                else if (hero.GetSpell() != null && hero.GetWeapon() == null) // hero only has a spell
                {
                    HeroAttackBySpell();
                }
                else // hero has a weapon and a spell
                {
                    if (hero.CanCast())
                        HeroAttackBySpell();
                    else
                        HeroAttackByWeapon();           
                }
            }

        }

        private void HeroAttackByWeapon()
        {
            if (heroRow - 1 > 0 && map[heroRow - 1, heroCol] == 'E')
            {
                foreach (var enemy in listOfEnemiesOnMap)
                {
                    if (enemy.EnemyRow == heroRow - 1 && enemy.EnemyCol == heroCol)
                    {
                        Fight(hero, enemy);
                        if (enemy.GetHealth() == 0)
                        {
                            Console.WriteLine("Enemy is dead.");
                            map[heroRow, heroCol] = '.';
                            heroRow--;
                            map[heroRow, heroCol] = 'H';
                        }
                        else
                        {
                            Console.WriteLine("You died.");
                            map[heroRow, heroCol] = '.';
                            Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                        }
                        break;
                    }
                }
            }
            else if (heroRow + 1 < map.GetLength(0) - 1 && map[heroRow + 1, heroCol] == 'E')
            {
                foreach (var enemy in listOfEnemiesOnMap)
                {
                    if (enemy.EnemyRow == heroRow + 1 && enemy.EnemyCol == heroCol)
                    {
                        Fight(hero, enemy);
                        if (enemy.GetHealth() == 0)
                        {
                            Console.WriteLine("Enemy is dead.");
                            map[heroRow, heroCol] = '.';
                            heroRow++;
                            map[heroRow, heroCol] = 'H';
                        }
                        else
                        {
                            Console.WriteLine("You died.");
                            map[heroRow, heroCol] = '.';
                            Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                        }
                        break;
                    }
                }
            }
            else if (heroCol - 1 > 0 && map[heroRow, heroCol - 1] == 'E')
            {
                foreach (var enemy in listOfEnemiesOnMap)
                {
                    if (enemy.EnemyRow == heroRow && enemy.EnemyCol == heroCol -  1)
                    {
                        Fight(hero, enemy);
                        if (enemy.GetHealth() == 0)
                        {
                            Console.WriteLine("Enemy is dead.");
                            map[heroRow, heroCol] = '.';
                            heroCol--;
                            map[heroRow, heroCol] = 'H';
                        }
                        else
                        {
                            Console.WriteLine("You died.");
                            map[heroRow, heroCol] = '.';
                            Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                        }
                        break;
                    }
                }
            }
            else if (heroCol + 1 < map.GetLength(1) - 1 && map[heroRow, heroCol + 1] == 'E')
            {
                foreach (var enemy in listOfEnemiesOnMap)
                {
                    if (enemy.EnemyRow == heroRow && enemy.EnemyCol == heroCol + 1)
                    {
                        Fight(hero, enemy);
                        if (enemy.GetHealth() == 0)
                        {
                            Console.WriteLine("Enemy is dead.");
                            map[heroRow, heroCol] = '.';
                            heroCol++;
                            map[heroRow, heroCol] = 'H';
                        }
                        else
                        {
                            Console.WriteLine("You died.");
                            map[heroRow, heroCol] = '.';
                            Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                        }
                        break;
                    }
                }
            }
        }

        private void HeroAttackBySpell()
        {
            for (int i = 1; i <= hero.GetSpell().CastRange; i++)
            {
                if (heroRow - i > 0 && map[heroRow - i, heroCol] == '#')
                    break;

                if (heroRow - i > 0 && map[heroRow - i, heroCol] == 'E')
                {
                    foreach (var enemy in listOfEnemiesOnMap)
                    {
                        if (enemy.EnemyRow == heroRow - i && enemy.EnemyCol == heroCol)
                        {
                            Fight(hero, enemy);
                            if (enemy.GetHealth() == 0)
                            {
                                Console.WriteLine("Enemy is dead.");
                                map[heroRow, heroCol] = '.';
                                heroRow -= i;
                                map[heroRow, heroCol] = 'H';
                            }
                            else
                            {
                                Console.WriteLine("You died.");
                                map[heroRow, heroCol] = '.';
                                Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                            }
                            return;
                        }
                    }
                }
            }

            for (int i = 1; i <= hero.GetSpell().CastRange; i++)
            {
                if (heroRow + i < map.GetLength(0) - 1 && map[heroRow + i, heroCol] == '#')
                    break;

                if (heroRow + i < map.GetLength(0) - 1 && map[heroRow + i, heroCol] == 'E')
                {
                    foreach (var enemy in listOfEnemiesOnMap)
                    {
                        if (enemy.EnemyRow == heroRow + i && enemy.EnemyCol == heroCol)
                        {
                            Fight(hero, enemy);
                            if (enemy.GetHealth() == 0)
                            {
                                Console.WriteLine("Enemy is dead.");
                                map[heroRow, heroCol] = '.';
                                heroRow += i;
                                map[heroRow, heroCol] = 'H';
                            }
                            else
                            {
                                Console.WriteLine("You died.");
                                map[heroRow, heroCol] = '.';
                                Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                            }
                            return;
                        }
                    }
                }
            }


            for (int i = 1; i <= hero.GetSpell().CastRange; i++)
            {
                if (heroCol - i > 0 && map[heroRow, heroCol - i] == '#')
                    break;

                if (heroCol - i > 0 && map[heroRow, heroCol - i] == 'E')
                {
                    foreach (var enemy in listOfEnemiesOnMap)
                    {
                        if (enemy.EnemyRow == heroRow && enemy.EnemyCol == heroCol - i)
                        {
                            Fight(hero, enemy);
                            if (enemy.GetHealth() == 0)
                            {
                                Console.WriteLine("Enemy is dead.");
                                map[heroRow, heroCol] = '.';
                                heroCol -= i;
                                map[heroRow, heroCol] = 'H';
                            }
                            else
                            {
                                Console.WriteLine("You died.");
                                map[heroRow, heroCol] = '.';
                                Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                            }
                            break;
                        }
                    }
                }
            }

            for (int i = 1; i <= hero.GetSpell().CastRange; i++)
            {
                if (heroCol + i < map.GetLength(1) - 1 && map[heroRow, heroCol + i] == '#')
                    break;

                if (heroCol + i < map.GetLength(1) - 1 && map[heroRow, heroCol + i] == 'E')
                {
                    foreach (var enemy in listOfEnemiesOnMap)
                    {
                        if (enemy.EnemyRow == heroRow && enemy.EnemyCol == heroCol + i)
                        {
                            Fight(hero, enemy);
                            if (enemy.GetHealth() == 0)
                            {
                                Console.WriteLine("Enemy is dead.");
                                map[heroRow, heroCol] = '.';
                                heroCol += i;
                                map[heroRow, heroCol] = 'H';
                            }
                            else
                            {
                                Console.WriteLine("You died.");
                                map[heroRow, heroCol] = '.';
                                Spawn(new Hero(hero.Name, hero.Title, hero.MaxHealth, hero.MaxMana, hero.ManaRegenerationRate));
                            }
                            break;
                        }
                    }
                }
            }

        }

    }
}