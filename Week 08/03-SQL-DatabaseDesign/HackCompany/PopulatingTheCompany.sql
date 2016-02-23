USE HackCompany

INSERT INTO Departments
VALUES ('Sales'),
	   ('Production'),
	   ('Financial');

INSERT INTO Employees (FirstName, LastName, Email, [Date of Birth])
VALUES ('Bill', 'Gates', 'billgates@microsoft.com', '10-28-1955');

INSERT INTO Employees (FirstName, LastName, Email, [Date of Birth], ManagerID, DepartmentID)
VALUES ('Rick', 'Symons', 'rickyboy@hackcompany.com', '05-10-1960', 1, 1),
	   ('Tracey', 'Cropper', 'tracycrop@hackcompany.com', '02-12-1974', 2, 1),
	   ('Chance', 'Newell', 'takethechance@hackcompany.com', '03-03-1975', 2, 1),
	   ('Teressa', 'Jones', 'tjones@hackcompany.com', '06-02-1980', 2, 1),
	   ('Samantha', 'Bush', 'samanthabush@hackcompany.com','05-03-1978', 2, 1);

INSERT INTO Employees (FirstName, LastName, Email, [Date of Birth], ManagerID, DepartmentID)
VALUES ('Bob', 'Jones', 'bob@hackcompany.com', '04-23-1990', 1, 2),
	   ('Paul', 'Andrews', 'pa@hackcompany.com', '12-06-1987', 7, 2),
	   ('Anna', 'Stephenson', 'annastephenson@hackcompany.com', '01-02-1979', 7, 2),
	   ('Emily', 'Stone', 'estone@hackcompany.com', '07-14-1979', 7, 2),
	   ('Barbara', 'Williams', 'bw@hackcompany.com', '12-11-1979', 7, 2);

INSERT INTO Employees (FirstName, LastName, Email, [Date of Birth], ManagerID, DepartmentID)
VALUES ('Zoey', 'Valentine', 'zoeyv@hackcompany.com', '09-20-1980', 1, 3),
	   ('Steven', 'Davidson', 'davids@hackcompany.com', '08-12-1982', 12, 3),
	   ('Brady', 'Willson', 'brady@hackcompany.com', '08-02-1986', 12, 3),
	   ('Stacy', 'Jackson', 'stacyj@hackcompany.com', '08-12-1982', 12, 3),
	   ('John', 'Barnes', 'johnb@hackcompany.com', '09-30-1982', 12, 3);

INSERT INTO Categories (CategoryID, Name)
VALUES ('BKS', 'Books'),
	   ('MSC','Music'),
	   ('HDW', 'Hardware'),
	   ('SFW', 'Software');

INSERT INTO Products (Name, [Single Price], CategoryID)
VALUES ('SQL for Dummies', 39.99, 'BKS'),
	   ('The Power of Now', 24.99, 'BKS'),
	   ('Steve Jobs: The Book', 29.99, 'BKS'),
	   ('Eminem albums', 19.99, 'MSC'),
	   ('Jay Z albums', 23.99, 'MSC'),
	   ('Notorious B.I.G. albums', 24.99, 'MSC'),
	   ('GeForce GT 710 2GB graphics card', 49.99, 'HDW'),
	   ('2 TB T3 SSD', 79.99, 'HDW'),
	   ('Acer Curved Gaming monitor', 259.99, 'HDW'),
	   ('MS SQL Server Management Studio', 59.99, 'SFW'),
	   ('Visual Studio 2015', 69.99, 'SFW'),
	   ('GTA V', 79.99, 'SFW');

INSERT INTO Customers (FirstName, LastName, Email, [Address], Discount)
VALUES ('Bob', 'Jones', null, '4484 Woodland Drive Los Angeles, CA 90008', 0.1),
	   ('Hailey', 'Adams', 'hadams@gmail.com', '3054 B Street Phoenix, AZ 85021', 0.05),
	   ('Tom', 'Bryant', null, '46 Route 20 Deltona, FL 32725', null),
	   ('Kevin', 'Jones', null, '535 Washington Avenue Stow, OH 44224', null),
	   ('Jessica', 'Alba', 'jalba@abv.bg', '161 Heritage Drive West Palm Beach, FL 33404', 0.2);

-- NOTE: The the price values are arbitrary numbers, not the real calculated values.
INSERT INTO Orders (OrderDate, CustomerID, TotalPrice)
VALUES ('2016-01-02T09:30:12', 2, 23.99),
	   ('2016-02-10T08:23:40', 1, 39.99),
	   ('2016-01-23T10:00:52', 5, 12.49),
	   ('2016-01-30T18:49:10', 4, 19.99),
	   ('2016-02-04T15:10:20', 3, 59.99);

INSERT INTO OrderProducts (OrderID, ProductID, Quantity)
VALUES (1, 3, 4),
	   (2, 1, 3),
	   (1, 8, 1),
	   (3, 10, 2),
	   (3, 2, 1),
	   (4, 1, 5),
	   (2, 9, 8),
	   (5, 6, 1),
	   (4, 11, 10),
	   (5, 2, 2);
