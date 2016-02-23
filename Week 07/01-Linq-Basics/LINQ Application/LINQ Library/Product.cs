using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Library
{
    public class Product
    {

        public Product(string name, int productID, int categoryID)
        {
            Name = name;
            ProductId = productID;
            CategoryId = categoryID;
        }

        public string Name { get; private set; }
        public int ProductId { get; private set; }
        public int CategoryId { get; private set; }

    }
}
