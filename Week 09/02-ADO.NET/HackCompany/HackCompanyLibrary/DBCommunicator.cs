using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HackCompanyLibrary
{
    public class DBCommunicator
    {
        private string connectionString;

        public DBCommunicator(string connectionString)
        {
            this.connectionString = connectionString;

            var sqlConnection = new SqlConnection(connectionString);    // testing the connection
            sqlConnection.Open();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                return command.ExecuteNonQuery();
            }
        }

        public void UpdateOrInsert(Category category)
        {            
            string query = $@"IF EXISTS (SELECT TOP 1 *
                                         FROM Categories
                                         WHERE CategoryID = '{category.ID}')
                                BEGIN
                                    UPDATE Categories
                                    SET Name = '{category.Name}'
                                    WHERE CategoryID = '{category.ID}'
                                END
                               ELSE
                                BEGIN
                                    INSERT INTO Categories
                                    VALUES ('{category.ID}', '{category.Name}')
                                END";

            ExecuteNonQuery(query);
        }

        public void UpdateOrInsert(Customer customer)
        {
            string query = $@"IF EXISTS (SELECT TOP 1 *
                                         FROM Customers
                                         WHERE CustomerID = {customer.ID})
                                BEGIN
                                    UPDATE Customers
                                    SET FirstName = '{customer.FirstName}'
                                    SET LastName = '{customer.LastName}'
                                    SET Email = '{customer.Email}'
                                    SET Address = '{customer.Address}'
                                    SET Discount = {customer.Discount}
                                    WHERE CustomerID = {customer.ID}    
                                END
                               ELSE
                                BEGIN
                                    SET IDENTITY_INSERT Customers ON
                                    INSERT INTO Customers
                                    VALUES ({customer.ID}, '{customer.FirstName}', '{customer.LastName}', '{customer.Email}', '{customer.Address}', {customer.Discount})
                                    SET IDENTITY_INSERT Customers OFF
                                END";

            ExecuteNonQuery(query);
        }

        public void UpdateOrInsert(Department department)
        {
            string query = $@"IF EXISTS (SELECT TOP 1 *
                                         FROM Departments
                                         WHERE DepartmentID = {department.ID})
                                BEGIN
                                UPDATE Departments
                                SET Name = '{department.Name}'
                                WHERE DepartmentID = {department.ID}
                                END
                               ELSE
                                BEGIN
                                SET IDENTITY_INSERT Departments ON
                                INSERT INTO Departments
                                VALUES ({department.ID}, '{department.Name}')
                                SET INDENTITY_INSERT Departments OFF
                                END";
            ExecuteNonQuery(query);
        }

        public void UpdateOrInsert(Employee employee)
        {
            string query = $@"IF EXISTS (SELECT TOP 1 *
                                         FROM Employees
                                         WHERE EmployeeID = {employee.ID})
                                BEGIN
                                UPDATE Employees
                                SET FirstName = '{employee.FirstName}'
                                SET LastName = '{employee.LastName}'
                                SET Email = '{employee.Email}'
                                SET [Date of Birth] = '{employee.BirthDate.ToString(@"yyyy-MM-dd")}'
                                SET ManagerID = {employee.ManagerID}
                                SET DepartmentID = {employee.DepartmentID}
                                WHERE EmployeeID = {employee.ID}
                                END
                               ELSE
                                BEGIN
                                SET IDENTITY_INSERT Employees ON
                                INSERT INTO Employees
                                VALUES ({employee.ID}, '{employee.FirstName}', '{employee.LastName}', '{employee.Email}', '{employee.BirthDate.ToString(@"yyyy-MM-dd")}', {employee.ManagerID}, {employee.DepartmentID})
                                SET IDENTITY_INSERT Employees OFF
                                END";
            ExecuteNonQuery(query);
        }

        public void UpdateOrInsert(Order order)
        {
            string query = $@"IF EXISTS (SELECT TOP 1 *
                                         FROM Orders
                                         WHERE OrderID = {order.ID})
                                BEGIN
                                UPDATE Orders
                                SET OrderDate = '{order.OrderDate.ToString(@"yyyy-MM-dd HH:mm:ss")}'
                                SET CustomerID = {order.CustomerID}
                                SET TotalPrice = {order.TotalPrice}
                                WHERE OrderID = {order.ID}
                                END
                               ELSE
                                BEGIN
                                SET IDENTITY_INSERT Orders ON
                                INSERT INTO Orders
                                VALUES ({order.ID}, '{order.OrderDate.ToString(@"yyyy-MM-dd HH:mm:ss")}', {order.CustomerID}, {order.TotalPrice})
                                SET IDENTITY_INSERT Orders OFF
                                END";
            ExecuteNonQuery(query);
        }

        public void UpdateOrInsert(OrderProduct orderProduct)
        {
            string query = $@"IF EXISTS (SELECT TOP 1 *
                                         FROM OrderProducts
                                         WHERE OrderID = {orderProduct.OrderID} AND ProductID = {orderProduct.ProductID})
                                BEGIN
                                UPDATE OrderProducts
                                SET Quantity = {orderProduct.Quantity}
                                WHERE OrderID = {orderProduct.OrderID} AND ProductID = {orderProduct.ProductID} 
                                END
                               ELSE
                                BEGIN
                                INSERT INTO OrderProducts
                                VALUES ({orderProduct.OrderID}, {orderProduct.ProductID}, {orderProduct.Quantity})
                                END";

            ExecuteNonQuery(query);
        }

        public void UpdateOrInsert(Product product)
        {
            string query = $@"IF EXISTS (SELECT TOP 1 *
                                         FROM Prodcuts
                                         WHERE ProductID = {product.ID})
                                BEGIN
                                UPDATE Products
                                SET Name = '{product.Name}'
                                SET [Single Price] = {product.SinglePrice}
                                SET CategoryID = '{product.CategoryID}'
                                WHERE ProductID = {product.ID}
                                END
                               ELSE
                                BEGIN
                                SET IDENTITY_INSERT Products ON
                                INSERT INTO Products
                                VALUES ({product.ID}, '{product.Name}', {product.SinglePrice}, '{product.CategoryID}')
                                SET IDENTITY_INSERT Products OFF
                                END";

            ExecuteNonQuery(query);
        }

        public bool DeleteCategory(string ID)
        {
            string query = $@"DELETE FROM Categories
                              WHERE CategoryID = '{ID}'";

            try
            {
                int affectedRows = ExecuteNonQuery(query);
                return affectedRows > 0;
            }
            catch(SqlException)
            {
                return false;
            }
        }

        public bool DeleteCustomer(int ID)
        {
            string query = $@"DELETE FROM Customers
                              WHERE CustomerID = {ID}";

            try
            {
                int affectedRows = ExecuteNonQuery(query);
                return affectedRows > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteDepartment(int ID)
        {
            string query = $@"DELETE FROM Departments
                              WHERE DepartmentID = {ID}";

            try
            {
                int affectedRows = ExecuteNonQuery(query);
                return affectedRows > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int ID)
        {
            string query = $@"DELETE FROM Employees
                              WHERE EmployeeID = {ID}";

            try
            {
                int affectedRows = ExecuteNonQuery(query);
                return affectedRows > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        } 

        public bool DeleteOrder(int ID)
        {
            string query = $@"DELETE FROM Orders
                            WHERE OrderID = {ID}";

            try
            {
                int affectedRows = ExecuteNonQuery(query);
                return affectedRows > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteOrderProduct(int orderID, int productID)
        {
            string query = $@"DELETE FROM OrderProducts
                              WHERE OrderID = {orderID} AND ProductID = {productID}";

            try
            {
                int affectedRows = ExecuteNonQuery(query);
                return affectedRows > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteProduct(int ID)
        {
            string query = $@"DELETE FROM Products
                              WHERE ProductID = {ID}";

            try
            {
                int affectedRows = ExecuteNonQuery(query);
                return affectedRows > 0;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        private object ObjectOrNull(object dbObj)
        {
            if (dbObj is DBNull)
                return null;
            else
                return dbObj;
        }

        public List<Category> GetAllCategories()
        {
            var rows = new List<Category>();

            string query = @"SELECT * FROM Categories";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        rows.Add(new Category((string)reader["CategoryID"], (string)reader["Name"]));
                    }
                }
            }

            return rows;
        }

        public List<Customer> GetAllCustomers()
        {
            var rows = new List<Customer>();

            string query = @"SELECT * FROM Customers";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        rows.Add(new Customer(
                            (int)reader["CustomerID"], 
                            (string)reader["FirstName"], 
                            (string)reader["LastName"], 
                            (string)ObjectOrNull(reader["Email"]), 
                            (string)reader["Address"], 
                            (float?)ObjectOrNull(reader["Discount"]))
                            );
                    }
                }
            }

            return rows;
        }

        public List<Department> GetAllDepartments()
        {
            var rows = new List<Department>();

            string query = @"SELECT * FROM Departments";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        rows.Add(new Department((int)reader["DepartmentID"], (string)reader["Name"]));
                    }
                }
            }

            return rows;
        }

        public List<Employee> GetAllEmployees()
        {
            var rows = new List<Employee>();

            string query = @"SELECT * FROM Employees";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        rows.Add(new Employee(
                            (int)reader["EmployeeID"],
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (string)ObjectOrNull(reader["Email"]),
                            (DateTime)reader["Date of Birth"],
                            (int?)ObjectOrNull(reader["ManagerID"]),
                            (int?)ObjectOrNull(reader["DepartmentID"]))
                            );
                    }
                }
            }

                return rows;
        }

        public List<Order> GetAllOrders()
        {
            var rows = new List<Order>();

            string query = @"SELECT * FROM Orders";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        rows.Add(new Order((int)reader["OrderID"], (DateTime)reader["OrderDate"], (int)reader["CustomerID"], (decimal)reader["TotalPrice"]));
                    }
                }
            }

            return rows;
        }

        public List<OrderProduct> GetAllOrderProducts()
        {
            var rows = new List<OrderProduct>();

            string query = @"SELECT * FROM OrderProducts";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        rows.Add(new OrderProduct((int)reader["OrderID"], (int)reader["ProductID"], (int)reader["Quantity"]));
                    }
                }
            }
            return rows;
        }

        public List<Product> GetAllProducts()
        {
            var rows = new List<Product>();

            string query = @"SELECT * FROM Products";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        rows.Add(new Product((int)reader["ProductID"], (string)reader["Name"], (decimal)reader["Single Price"], (string)reader["CategoryID"]));
                    }
                }
            }
            return rows;
        }

        public Category GetCategory(string ID)
        {
            string query = $@"SELECT TOP 1 *
                            FROM Categories
                            WHERE CategoryID = '{ID}'";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                
                using(var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new Category((string)reader["CategoryID"], (string)reader["Name"]);
                    else
                        return null;
                } 
            }
        }

        public Customer GetCustomer(int ID)
        {
            string query = $@"SELECT TOP 1 *
                              FROM Customers
                              WHERE CustomerID = {ID}";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new Customer((int)reader["CustomerID"],
                                            (string)reader["FirstName"],
                                            (string)reader["LastName"],
                                            (string)ObjectOrNull(reader["Email"]),
                                            (string)reader["Address"],
                                            (float?)ObjectOrNull(reader["Discount"])
                                            );
                    else
                        return null;
                }
            }
        }

        public Department GetDepartment(int ID)
        {
            string query = $@"SELECT TOP 1 *
                              FROM Departments
                              WHERE DepartmentID = {ID}";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new Department((int)reader["DepartmentID"], (string)reader["Name"]);
                    else
                        return null;
                }
            }
        }

        public Employee GetEmployee(int ID)
        {
            string query = $@"SELECT TOP 1 *
                              FROM Employees
                              WHERE EmployeeID = {ID}";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new Employee((int)reader["EmployeeID"],
                                            (string)reader["FirstName"],
                                            (string)reader["LastName"],
                                            (string)ObjectOrNull(reader["Email"]),
                                            (DateTime)reader["Date of Birth"],
                                            (int?)ObjectOrNull(reader["ManagerID"]),
                                            (int?)ObjectOrNull(reader["DepartmentID"])
                                            );
                    else
                        return null;
                }
            }
        }

        public Order GetOrder(int ID)
        {
            string query = $@"SELECT TOP 1 *
                              FROM Orders
                              WHERE OrderID = {ID}";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new Order((int)reader["OrderID"],
                                         (DateTime)reader["OrderDate"],
                                         (int)reader["CustomerID"],
                                         (decimal)reader["TotalPrice"]
                                         );
                    else
                        return null;
                }
            }
        }

        public OrderProduct GetOrderProduct(int orderID, int prodID)
        {
            string query = $@"SELECT TOP 1 *
                              FROM OrderProducts
                              WHERE OrderID = {orderID} AND ProductID = {prodID}";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new OrderProduct((int)reader["OrderID"],
                                                (int)reader["ProductID"],
                                                (int)reader["Quantity"]
                                                );
                    else
                        return null;
                }
            }
        }

        public Product GetProduct(int ID)
        {
            string query = $@"SELECT TOP 1 *
                              FROM Products
                              WHERE ProductID = {ID}";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return new Product((int)reader["ProductID"],
                                           (string)reader["Name"],
                                           (decimal)reader["Single Price"],
                                           (string)reader["CategoryID"]
                                           );
                    else
                        return null;
                }
            }
        }
    }
}