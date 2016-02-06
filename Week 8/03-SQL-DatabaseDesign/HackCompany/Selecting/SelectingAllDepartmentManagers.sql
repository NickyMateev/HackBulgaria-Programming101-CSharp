USE HackCompany

SELECT *
FROM Employees
WHERE ManagerID =
	(SELECT EmployeeID
	FROM Employees
	WHERE ManagerID IS NULL);