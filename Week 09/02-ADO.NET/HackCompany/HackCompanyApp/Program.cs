using System;
using System.Configuration;
using HackCompanyLibrary;

namespace HackCompanyApp
{
    class Program
    {
        static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HackCompany"].ConnectionString;

            DBCommunicator communicator = new DBCommunicator(connectionString);

            foreach (var e in communicator.GetAllEmployees())
            {
                Console.WriteLine($"{e.FirstName}, {e.LastName}, {e.Email}, {e.BirthDate}, {e.ManagerID}, {e.DepartmentID}");
            }
        }
    }
}
