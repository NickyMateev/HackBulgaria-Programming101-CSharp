using System;
using System.Collections.Generic;
using Shop_Inventory__Library_;

namespace ShopInventoryApp
{
    class ShopInventoryApplication
    {
        static void Main()
        {
            List<Product> listOfProducts = new List<Product>()
            {
                new Product(1, "Bulgaria", "apple", 2, 1000),
                new Product(2.4m, "United Kingdom", "chicken", 3, 1001),
                new Product(1.2m, "Germany", "potatoes", 1, 1002),
                new Product(3.4m, "Italy", "cucumber", 3, 1003),
                new Product(0.5m, "France", "chocolate", 10, 1004)
            };

            ShopInventory shop = new ShopInventory(listOfProducts);
            Console.WriteLine("If all products were sold out you'd earn: $" + shop.Audit());

            List<int> IDs = new List<int>() { 1000, 1001, 1002, 1003, 1004 };
            List<int> Quantities = new List<int>() { 2, 3, 1, 3, 10 };

            Order order = new Order(IDs, Quantities);
            Console.WriteLine("Total amount to pay: ${0}", shop.RequestOrder(order));
        }
    }
}