using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Library
{
    public class DataStore
    {
        private List<Product> listOfProducts;
        private List<Category> listOfCategories;
        private List<Order> listOfOrders;

        public DataStore()
        {
            listOfProducts = new List<Product>();
            listOfCategories = new List<Category>();
            listOfOrders = new List<Order>();
        }

        public DataStore(List<Product> productList, List<Category> categoryList, List<Order> ordersList)
        {
            listOfProducts = productList;
            listOfCategories = categoryList;
            listOfOrders = ordersList;
        }

        public void AddProduct(Product product)
        {
            listOfProducts.Add(product);
        }

        public void AddCategory(Category category)
        {
            listOfCategories.Add(category);
        }

        public void AddOrder(Order order)
        {
            listOfOrders.Add(order);
        }

        public List<Product> GetProducts()
        {
            return listOfProducts;   
        }

        public List<Category> GetCategories()
        {
            return listOfCategories;
        }

        public List<Order> GetOrders()
        {
            return listOfOrders;
        }


    }
}
