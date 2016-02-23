using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCompanyLibrary
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public float? Discount { get; set; }

        public Customer(int id, string firstName, string lastName, string email, string address, float? discount)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            Discount = discount;
        }
    }
}
