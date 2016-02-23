using System;

namespace EmployeeLibrary
{
    public partial class Employee
    {
        partial void Print()
        {
            Console.WriteLine(FirstName + " " + LastName);
        }

        public decimal CalculateAllIncome()
        {
            return Salary + Bonus;
        }

        public decimal CalculateBalance()
        {
            return (Salary + Bonus) * 4 / 5;
        }
    }
}