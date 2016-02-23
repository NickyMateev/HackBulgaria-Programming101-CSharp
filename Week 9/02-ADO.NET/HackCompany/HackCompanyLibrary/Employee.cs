using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCompanyLibrary
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }     // see if it works
        public int? ManagerID { get; set; }
        public int? DepartmentID { get; set; }

        public Employee(int id, string firstName, string lastName, string email, DateTime birthDate, int? managerId, int? departmentId)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            ManagerID = managerId;
            DepartmentID = departmentId;
        }
    }
}
