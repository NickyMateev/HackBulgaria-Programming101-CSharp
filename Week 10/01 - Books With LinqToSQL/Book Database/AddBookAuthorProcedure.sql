USE BookDatabase

GO

CREATE PROCEDURE AddBookAuthorRecord
@bookID INT,
@authorID INT
AS
BEGIN

INSERT INTO BookAuthor (BookID, AuthorID)
VALUES (@bookID, @authorID)

END