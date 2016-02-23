using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Library
{
    public class Order
    {
        public Order(int orderID, List<int> listOfProducts, DateTime orderDate, string name)
        {
            OrderId = orderID;
            Products = listOfProducts;
            OrderDate = orderDate;
            Name = name;
        }

        public int OrderId { get; private set; }
        public List<int> Products { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string Name { get; private set; }
    }
}
