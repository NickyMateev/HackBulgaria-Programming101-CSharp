USE HackCompany

SELECT TOP 1 op.OrderID, o.OrderDate, o.CustomerID, SUM(op.Quantity) as [Number Of Products], o.TotalPrice
FROM OrderProducts op
JOIN Orders o
ON op.OrderID = o.OrderID
GROUP BY op.OrderID, o.OrderDate, o.CustomerID, o.TotalPrice
ORDER BY SUM(op.Quantity) DESC;