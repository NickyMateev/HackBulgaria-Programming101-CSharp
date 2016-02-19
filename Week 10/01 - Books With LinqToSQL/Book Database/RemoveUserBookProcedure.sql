USE BookDatabase

GO

CREATE PROCEDURE RemoveUserBookRecord
@userID INT,
@bookID INT
AS
BEGIN

DELETE FROM UserBook
WHERE UserID = @userID AND BookID = @bookID

END