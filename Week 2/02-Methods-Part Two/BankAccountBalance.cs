using System;
using System.IO;

namespace Bank_Account_Balance
{
    struct Transaction
    {
        public DateTime date;
        public string operation;
        public double amount;
    }

    class BankAccountBalance
    {
        static void GetTransactions(string filePath, DateTime startDate, DateTime endDate)
        {
            string[] transactions = File.ReadAllLines(filePath);

            Transaction[] transactionsInformation = new Transaction[transactions.Length];

            string[] currentTransaction = new string[3];    // 0 - date, 1 - operation, 2 - amount
            for (int i = 0; i < transactions.Length; i++)
            {
                currentTransaction = transactions[i].Split(';');

                // get date
                string temp = "";
                for (int j = 0; j < currentTransaction[0].Length; j++)  // this for cycle will weed out unwanted characters
                {
                    if ((currentTransaction[0][j] >= 48 && currentTransaction[0][j] <= 57) || currentTransaction[0][j] == '.')
                    {
                        temp += currentTransaction[0][j];
                    }
                }
                string[] tempDate = temp.Split('.');
                transactionsInformation[i].date = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[1]), int.Parse(tempDate[0]));  // years, months and days

                // get operation
                transactionsInformation[i].operation = currentTransaction[1];

                // get amount
                temp = "";
                for (int j = 0; j < currentTransaction[2].Length; j++)  // this for cycle will weed out unwanted characters
                {
                    if ((currentTransaction[2][j] >= 48 && currentTransaction[2][j] <= 57) || currentTransaction[2][j] == '.')
                    {
                        temp += currentTransaction[2][j];
                    }
                }
                transactionsInformation[i].amount = double.Parse(temp);
            }

            // now in the transactionsInformation array we have the specific information(date, operation, amount) for each transaction

            // check if startDate < the last transaction date -> no transactions
            if (startDate > transactionsInformation[transactionsInformation.Length - 1].date)
            {
                Console.WriteLine("There have been no transactions in the specified period.");
                return;
            }
            // else cycle through the dates
            double received = 0;
            double spent = 0;

            for (; startDate <= endDate; startDate = startDate.AddDays(1))
            {
                for (int j = 0; j < transactionsInformation.Length; j++)
                {
                    if (startDate == transactionsInformation[j].date)
                    {
                        Console.WriteLine(transactions[j]);
                        if (transactionsInformation[j].operation == "received")
                            received += transactionsInformation[j].amount;
                        else if (transactionsInformation[j].operation == "spent")
                            spent += transactionsInformation[j].amount;
                        else
                            throw new ArgumentException("ERROR: Unknown transaction operation!");
                        break;
                    }
                }
                if (startDate > transactionsInformation[transactionsInformation.Length - 1].date)
                    break;
            }

            Console.WriteLine("\nTotal balance: ${0}", received - spent);
        }

        static void Main()
        {
            string path = @"C:\Users\Nicky\Desktop\Activity.txt";
            Console.Write("\t\t\tEnter a time period\nStart date: ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("End date: ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            GetTransactions(path, startDate, endDate);
        }
    }
}