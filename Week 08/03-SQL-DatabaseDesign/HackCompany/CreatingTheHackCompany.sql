CREATE DATABASE HackCompany

CREATE TABLE Departments (
		DepartmentID INT identity(1,1) PRIMARY KEY,
		Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Employees (
		EmployeeID INT identity(1,1) PRIMARY KEY,
		FirstName NVARCHAR(50) NOT NULL,
		LastName NVARCHAR(50) NOT NULL,
		Email NVARCHAR(50) NULL,
		[Date of Birth] DATE NOT NULL,
		ManagerID INT NULL,
		DepartmentID int NULL,
		FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
		FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID)
);

CREATE TABLE Categories (
		CategoryID NCHAR(3) PRIMARY KEY,
		Name NVARCHAR(50) NOT NULL
);

CREATE TABLE Products (
		ProductID INT identity(1,1) PRIMARY KEY,
		Name NVARCHAR(50) NOT NULL,
		[Single Price] MONEY NOT NULL,
		CategoryID NCHAR(3) NOT NULL,
		FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE Customers (
		CustomerID INT identity(1,1) PRIMARY KEY,
		FirstName NVARCHAR(50) NOT NULL,
		LastName NVARCHAR(50) NOT NULL,
		Email NVARCHAR(50) NULL,
		[Address] NVARCHAR(50) NOT NULL,
		Discount FLOAT NULL
);

CREATE TABLE Orders (
		OrderID INT IDENTITY(1,1) PRIMARY KEY,
		OrderDate DATETIME NOT NULL,
		CustomerID INT NOT NULL,
		TotalPrice MONEY NOT NULL,
		FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderProducts (
		OrderID INT NOT NULL,
		ProductID INT NOT NULL,
		Quantity INT NOT NULL,
		FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
		FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);