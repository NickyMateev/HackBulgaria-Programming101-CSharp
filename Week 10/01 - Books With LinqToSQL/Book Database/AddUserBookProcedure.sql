USE BookDatabase

GO

CREATE PROCEDURE AddUserBookRecord
@bookID INT,
@userID INT,
@copy INT,
@dateGiven DATE,
@dateReturn DATE
AS
BEGIN

INSERT INTO UserBook (BookID, UserID, [Copy #], [Date given], [Date to return])
VALUES (@bookID, @userID, @copy, @dateGiven, @dateReturn)

END