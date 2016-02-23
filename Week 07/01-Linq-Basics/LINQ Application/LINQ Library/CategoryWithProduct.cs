using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Library
{
    public class CategoryWithProduct
    {
        public CategoryWithProduct(string categoryName, List<string> productNames, int categoryId)
        {
            CategoryName = categoryName;
            ProductNames = productNames;
            CategoryId = categoryId;
        }

        public string CategoryName { get; private set; }
        public List<string> ProductNames { get; private set; }
        public int CategoryId { get; private set; }
    }
}
