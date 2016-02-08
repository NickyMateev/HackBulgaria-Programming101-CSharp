USE HackCompany

GO

CREATE PROCEDURE GetNumberOfOrders
@productID INT
AS
BEGIN

SELECT ProductID, SUM(Quantity) as [Times Ordered]
FROM OrderProducts
GROUP BY ProductID
HAVING ProductID = @productID

END