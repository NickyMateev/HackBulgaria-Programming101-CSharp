using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Library
{
    public class Category
    {
        public Category(int categoryID, string categoryName)
        {
            CategoryId = categoryID;
            CategoryName = categoryName;
        }

        public int CategoryId { get; private set; }
        public string CategoryName { get; private set; }
    }
}