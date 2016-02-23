USE HackCompany

SELECT d.DepartmentID, d.Name, COUNT(*) as [Number Of Employees]
FROM Departments d
JOIN Employees e
ON d.DepartmentID = e.DepartmentID
GROUP BY d.DepartmentID, d.Name
HAVING COUNT(*) > 3;