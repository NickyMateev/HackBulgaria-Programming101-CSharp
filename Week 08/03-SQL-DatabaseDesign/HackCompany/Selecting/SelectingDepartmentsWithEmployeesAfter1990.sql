USE HackCompany

SELECT d.DepartmentID, d.Name
FROM Departments d
JOIN Employees e
ON d.DepartmentID = e.DepartmentID
WHERE e.[Date of Birth] >= '01-01-1990';