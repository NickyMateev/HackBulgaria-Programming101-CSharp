using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCompanyLibrary
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalPrice { get; set; }

        public Order(int id, DateTime orderDate, int customerId, decimal totalPrice)
        {
            ID = id;
            OrderDate = orderDate;
            CustomerID = customerId;
            TotalPrice = totalPrice;
        }
    }
}
