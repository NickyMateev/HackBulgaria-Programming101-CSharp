using System;
using EmployeeLibrary;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            Employee emp = new Employee("Steve", "Jobs", 100000.0m, "CEO", 20000.0m);
            Console.WriteLine(emp.CalculateBalance());
            emp.PrintName();
        }
    }
}
