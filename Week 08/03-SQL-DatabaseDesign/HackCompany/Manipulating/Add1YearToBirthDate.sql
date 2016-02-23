USE HackCompany

UPDATE Employees
SET [Date of Birth] = DATEADD(YEAR, 1, [Date of Birth]);