namespace EmployeeLibrary
{
    public partial class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Salary { get; private set; }
        public string Position { get; private set; }
        public decimal Bonus { get; private set; }

        public Employee(string firstName, string lastName, decimal salary, string position, decimal bonus)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Position = position;
            Bonus = bonus;
        }

        partial void Print();

        public void PrintName()
        {
            Print();
        }

    }
}