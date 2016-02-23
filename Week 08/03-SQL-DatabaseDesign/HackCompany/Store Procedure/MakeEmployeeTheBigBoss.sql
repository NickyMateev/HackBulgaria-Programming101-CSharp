USE HackCompany

GO

ALTER PROCEDURE MakeEmployeeTheBigBoss
@employeeID INT
AS
BEGIN

DECLARE @employeeFirstName NVARCHAR(50) = (SELECT e.FirstName FROM Employees e WHERE e.EmployeeID = @employeeID)
DECLARE @employeeLastName NVARCHAR(50) = (SELECT e.LastName FROM Employees e WHERE e.EmployeeID = @employeeID)
DECLARE @employeeEmail NVARCHAR(50) = (SELECT e.Email FROM Employees e WHERE e.EmployeeID = @employeeID)
DECLARE @employeeBirthDate DATE = (SELECT e.[Date of Birth] FROM Employees e WHERE e.EmployeeID = @employeeID)
DECLARE @bigBossFirstName NVARCHAR(50) = (SELECT e.FirstName FROM Employees e WHERE e.ManagerID IS NULL)
DECLARE @bigBossLastName NVARCHAR(50) = (SELECT e.LastName FROM Employees e WHERE e.ManagerID IS NULL)
DECLARE @bigBossEmail NVARCHAR(50) = (SELECT e.Email FROM Employees e WHERE e.ManagerID IS NULL)
DECLARE @bigBossBirthDate DATE = (SELECT e.[Date of Birth] FROM Employees e WHERE e.ManagerID IS NULL)
 
-- making the boss a regular employee
UPDATE Employees
SET FirstName = @bigBossFirstName,
	LastName = @bigBossLastName,
	Email = @bigBossEmail,
	[Date of Birth] = @bigBossBirthDate
WHERE EmployeeID = @employeeID

-- making regular employee the boss
UPDATE Employees
SET FirstName = @employeeFirstName,
	LastName = @employeeLastName,
	Email = @employeeEmail,
	[Date of Birth] = @employeeBirthDate
WHERE ManagerID IS NULL

END