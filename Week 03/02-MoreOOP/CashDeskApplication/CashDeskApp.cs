using System;
using System.Collections.Generic;
using System.Text;
using Cash_Desk;

namespace CashDeskApplication
{
    class CashDeskApp
    {
        static bool isValidCoin(int amount)
        {
            if (amount == 1 || amount == 2 || amount == 5 || amount == 10 || amount == 20 || amount == 50 || amount == 100)
                return true;
            else
                return false;
        }

        static bool isValidBill(int amount)
        {
            if (amount == 2 || amount == 5 || amount == 10 || amount == 20 || amount == 50 || amount == 100)
                return true;
            else
                return false;
        }

        static void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(new string('-', Console.WindowWidth));
            Console.WriteLine("takebill <number> - adds a bill with value <number> to the CashDesk");
            Console.WriteLine("takecoin <number> - adds a coin with value <number> to the CashDesk");
            Console.WriteLine("takebatchbill <number1> <number2> ... - adds a batch of bills to the CashDesk");
            Console.WriteLine("takebatchcoin <number1> <number2> ... - adds a batch of coins to the CashDesk");
            Console.WriteLine("total - prints the total money in the CashDesk");
            Console.WriteLine("inspect - prints detailed information of the money in the CashDesk");
            Console.WriteLine("exit - exits the application");
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        static void Main()
        {
            CashDesk desk = new CashDesk();
            bool quitNow = false;

            Console.SetCursorPosition(Console.WindowWidth / 3, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CashDesk application\n");
            Console.WriteLine("/help - for the full list of commands\n\n");

            StringBuilder userInput = new StringBuilder();

            while(!quitNow)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                userInput.Append(Console.ReadLine());

                if (userInput.ToString().Contains("takebill"))  // 1st command ---------------------------------
                {
                    userInput.Replace("takebill", ""); // this way we remove the 'takebill' substring from the whole string
                    int amount = -1;
                    if (int.TryParse(userInput.ToString(), out amount))
                    {
                        if (isValidBill(amount))
                            desk.TakeMoney(new Bill(amount));
                        else
                            Console.WriteLine("Your ${0} bill was rejected because it's not a valid bill!", amount);
                    }
                    else
                        Console.WriteLine("ERROR: Invalid amount!");

                }
                else if (userInput.ToString().Contains("takecoin"))  // 2nd command ---------------------------------
                {
                    userInput.Replace("takecoin", "");
                    int amount = -1;
                    if (int.TryParse(userInput.ToString(), out amount))
                    {
                        if (isValidCoin(amount))
                            desk.TakeMoney(new Coin(amount));
                        else
                            Console.WriteLine("Your {0}c coin was rejected because it's not a valid coin!", amount);
                    }
                    else
                        Console.WriteLine("ERROR: Invalid amount!");
                }
                else if (userInput.ToString().Contains("takebatchbill"))   // 3rd command ---------------------------------
                {
                    userInput.Replace("takebatchbill", ""); // this way we remove the 'takebatchbill' substring from the whole string
                    List<Bill> listOfBills = new List<Bill>();

                    string[] arrayOfBills = userInput.ToString().Split(' ');
                    int amount = -1;
                    foreach (var bill in arrayOfBills)
                    {
                        if (int.TryParse(bill, out amount))
                        {
                            if (isValidBill(amount))
                                listOfBills.Add(new Bill(amount));
                            else
                                Console.WriteLine("Your ${0} bill was rejected because it's not a valid bill!", amount);
                        }
                    }

                    if (listOfBills.Count == 0)
                        Console.WriteLine("ERROR: Invalid amount!");
                    else
                        desk.TakeMoney(new BatchBill(listOfBills));
                    
                }
                else if (userInput.ToString().Contains("takebatchcoin"))  // 4th command  ---------------------------------
                {
                    userInput.Replace("takebatchcoin", "");
                    List<Coin> listOfCoins = new List<Coin>();

                    string[] arrayOfCoins = userInput.ToString().Split(' ');
                    int amount = -1;
                    foreach (var coin in arrayOfCoins)
                    {
                        if (int.TryParse(coin, out amount))
                        {
                            if (isValidCoin(amount))
                                listOfCoins.Add(new Coin(amount));
                            else
                                Console.WriteLine("Your {0}c coin was rejected because it's not a valid coin!", amount);
                        }
                    }

                    if (listOfCoins.Count == 0)
                        Console.WriteLine("ERROR: Invalid amount!");
                    else
                        desk.TakeMoney(new BatchCoin(listOfCoins));

                }
                else if (userInput.ToString().Contains("total"))  // 5th command ---------------------------------
                {
                    Console.WriteLine("${0} and {1}c", desk.Total(), desk.TotalCoins());
                }
                else if (userInput.ToString().Contains("inspect"))  // 6th command ---------------------------------
                {
                    if (desk.Total() != 0 || desk.TotalCoins() != 0)
                        desk.Inspect();
                    else
                        Console.WriteLine("The Cash Desk is empty right now.");
                    
                }
                else if(userInput.ToString().Contains("exit"))  // 7th command ---------------------------------
                {
                    quitNow = true;
                }
                else if(userInput.ToString().Contains("/help"))  //8th command ---------------------------------
                {
                    PrintHelp();
                }
                else
                    Console.WriteLine("ERROR: Invalid command!");

                userInput.Clear();
            }
        }
    }
}