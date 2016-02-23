USE HackCompany

UPDATE Customers
SET Discount = Discount * 2
WHERE CustomerID = ( SELECT TOP 1 c.CustomerID
					 FROM Orders o
					 JOIN Customers c
					 ON o.CustomerID = c.CustomerID
				   	 GROUP BY c.CustomerID
					 ORDER BY COUNT(*) DESC);