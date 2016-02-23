using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCompanyLibrary
{
    public class OrderProduct
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public OrderProduct(int orderId, int productId, int quantity)
        {
            OrderID = orderId;
            ProductID = productId;
            Quantity = quantity;
        }
    }
}
