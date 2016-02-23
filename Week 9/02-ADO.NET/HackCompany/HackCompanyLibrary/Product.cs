using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCompanyLibrary
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal SinglePrice { get; set; }
        public string CategoryID { get; set; }

        public Product(int id, string name, decimal singlePrice, string categoryId)
        {
            ID = id;
            Name = name;
            SinglePrice = singlePrice;
            CategoryID = categoryId;
        }
    }
}
