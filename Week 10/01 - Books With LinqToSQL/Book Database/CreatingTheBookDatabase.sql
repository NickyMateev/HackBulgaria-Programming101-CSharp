CREATE DATABASE BookDatabase

CREATE TABLE Books
(
	BookID INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[Date Published] DATE NOT NULL,
	Publisher NVARCHAR(100) NOT NULL,
	Genre NVARCHAR(50) NOT NULL,
	Pages INT NOT NULL,
	ISBN INT NOT NULL,
	[Number of copies] INT NOT NULL
)

CREATE TABLE Authors
(
	AuthorID INT IDENTITY(1,1) PRIMARY KEY,
	[First Name] NVARCHAR(100) NOT NULL,
	[Last Name] NVARCHAR(100) NOT NULL,
	[Year Born] INT NOT NULL,
	[Year Died] INT NULL
)

CREATE TABLE BookAuthor
(
	BookID INT NOT NULL,
	AuthorID INT NOT NULL,
	FOREIGN KEY (BookID) REFERENCES Books(BookID),
	FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
)

CREATE TABLE Users
(
	UserID INT IDENTITY(1,1) PRIMARY KEY,
	[First Name] NVARCHAR(50) NOT NULL,
	[Last Name]  NVARCHAR(50) NOT NULL,
	Pseudonim NVARCHAR(50) NULL,
	Email NVARCHAR(100) NULL,
	Phone INT NOT NULL,
	[Books lent] INT NOT NULL
)

CREATE TABLE UserBook
(
	UserID INT NOT NULL,
	BookID INT NOT NULL,
	[Copy #] INT NOT NULL,
	[Date given] DATE NOT NULL,
	[Date to return] DATE NOT NULL,
	FOREIGN KEY (UserID) REFERENCES Users(UserID),
	FOREIGN KEY (BookID) REFERENCES Books(BookID)
)

select *
from Books