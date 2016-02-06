USE HackCompany

SELECT TOP 1 d.DepartmentID, d.Name, COUNT(*) as [Number Of Employees]
FROM Departments d
JOIN Employees e
ON d.DepartmentID = e.DepartmentID
GROUP BY d.DepartmentID, d.Name
ORDER BY COUNT(*) DESC;