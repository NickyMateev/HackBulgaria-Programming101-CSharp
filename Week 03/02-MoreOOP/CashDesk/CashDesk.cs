using System;
using System.Collections.Generic;
using System.Linq;

namespace Cash_Desk
{
    public class CashDesk
    {
        private Dictionary<Bill, int> billCashDesk = new Dictionary<Bill, int>();
        private Dictionary<Coin, int> coinCashDesk = new Dictionary<Coin, int>();

        public void TakeMoney(Bill bill)
        {
            if (billCashDesk.ContainsKey(bill))
                billCashDesk[bill]++;
            else
                billCashDesk.Add(bill, 1);
        }

        public void TakeMoney(BatchBill batchBill)
        {
            foreach (Bill bill in batchBill)
            {
                if (billCashDesk.ContainsKey(bill))
                    billCashDesk[bill]++;
                else
                    billCashDesk.Add(bill, 1);
            }
        }

        public void TakeMoney(Coin coin)
        {
            if (coinCashDesk.ContainsKey(coin))
                coinCashDesk[coin]++;
            else
                coinCashDesk.Add(coin, 1);
        }

        public void TakeMoney(BatchCoin batchCoin)
        {
            foreach (Coin coin in batchCoin)
            {
                if (coinCashDesk.ContainsKey(coin))
                    coinCashDesk[coin]++;
                else
                    coinCashDesk.Add(coin, 1);
            }
        }

        public int Total()
        {
            int sum = 0;
            foreach (var bill in billCashDesk)
            {
                sum += bill.Key.Value() * bill.Value;   // bill * copies of the bill
            }
            return sum;
        }

        public int TotalCoins()
        {
            int sum = 0;
            foreach (var coin in coinCashDesk)
            {
                sum += coin.Key.Value() * coin.Value;   // coin * copies of the coin
            }
            return sum;
        }

        public void Inspect()
        {
            var orderedBills = from pair in billCashDesk orderby pair.Key.Value() ascending select pair;
            var orderedCoins = from pair in coinCashDesk orderby pair.Key.Value() ascending select pair;

            foreach (var pair in orderedBills)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            foreach (var pair in orderedCoins)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }

    }
}