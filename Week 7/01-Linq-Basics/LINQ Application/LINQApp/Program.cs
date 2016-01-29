using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Library;

namespace LINQ_Library
{
    class Program
    {
        static void Main()
        {
            List<Product> products = new List<Product>() {
                new Product("Candy", 1, 101),
                new Product("Wine", 45, 140),
                new Product("Bread", 87, 101),
                new Product("IPhone", 24, 112),
                new Product("Laptop", 65, 110),
                new Product("Pants", 75, 180),
                new Product("Suit", 23, 180),
                new Product("The Power of Habit", 60, 132),
                new Product("Table", 10, 168)
            };

            List<Category> categories = new List<Category>()
            {
                new Category(101, "Food"),
                new Category(110, "Computers and Laptops"),
                new Category(112, "Phones"),
                new Category(132, "Education"),
                new Category(140, "Drinks"),
                new Category(168, "Home"),
                new Category(180, "Clothes")
            };

            List<Order> orders = new List<Order>()
            {
                new Order(201, new List<int>() {45, 23, 10}, new DateTime(2016, 01, 20, 7, 30, 00), "order1"),
                new Order(240, new List<int>() {1, 87, 75, 23 }, new DateTime(2016, 01, 21, 8, 00, 00), "order2"),
                new Order(263, new List<int>() {24, 65, 60 }, new DateTime(2016, 01, 24, 9, 20, 00), "order3"),
                new Order(290, new List<int>() {23, 75, 24, 45 }, new DateTime(2016, 01, 25, 10, 30, 00), "order4"),
                new Order(220, new List<int>() {87, 24, 23 }, new DateTime(2016, 01, 26, 10, 00, 00), "order5")
            };

            DataStore store = new DataStore(products, categories, orders);

            var firstQuery = from product in store.GetProducts()
                             where product.ProductId >= 15
                             && product.ProductId <= 30
                             select product;

            var secondQuery = from category in store.GetCategories()
                              where category.CategoryId >= 105
                              && category.CategoryId <= 125
                              select category;

            var thirdQuery = (from order in store.GetOrders()
                             orderby order.Name
                             select order).Take(15);

            var fourthQuery = (from order in store.GetOrders()
                              where order.Products.Contains(23)
                              orderby order.OrderDate
                              select order.OrderDate).Take(3);

            var fifthQuery = from category in store.GetCategories()
                             join product in store.GetProducts() on category.CategoryId equals product.CategoryId
                             orderby category.CategoryName
                             select new { ProductName = product.Name, CategoryName = category.CategoryName };

            var sixthQuery = from category in store.GetCategories()
                             join product in store.GetProducts() on category.CategoryId equals product.CategoryId into productsGroup
                             let productNames = ( from prod in productsGroup
                                                  select prod.Name)
                             select new { CategoryName = category.CategoryName, ProductNames = productNames.ToList() };

            var seventhQuery = from order in store.GetOrders()
                               let productsList = (from productId in order.Products
                                                   join product in store.GetProducts() on productId equals product.ProductId
                                                   join category in store.GetCategories() on product.CategoryId equals category.CategoryId
                                                   select new { ProductName = product.Name, CategoryName = category.CategoryName })
                               orderby order.OrderDate
                               select new
                               {
                                   OrderName = order.Name,
                                   OrderDate = order.OrderDate,
                                   ProductsWithCategory = productsList
                               };


            foreach (var item in seventhQuery)
            {
                Console.Write($"{item.OrderName} - {item.OrderDate}");
                foreach (var product in item.ProductsWithCategory)
                {
                    Console.Write($" {product.ProductName} - {product.CategoryName}, ");
                }
                Console.WriteLine();
            }

        }
    }
}