using System;
using System.Collections.Generic;
using System.Linq;

namespace Book_App
{
    class BookApp
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tBook Store App");

            bool continueRunning = true;
            string userInput = string.Empty;

            Console.ForegroundColor = ConsoleColor.Cyan;
            while(continueRunning)
            {
                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                if (userInput.Contains("insertbook"))
                {
                    string title, description, datePublished, publisher, genre;
                    int pages, isbn, numberOfCopies;
                    Console.Write("Title: ");
                    title = Console.ReadLine();
                    Console.Write("Description: ");
                    description = Console.ReadLine();
                    Console.Write("Date published: ");
                    datePublished = Console.ReadLine();
                    Console.Write("Publisher: ");
                    publisher = Console.ReadLine();
                    Console.Write("Genre: ");
                    genre = Console.ReadLine();
                    Console.Write("Pages: ");
                    pages = int.Parse(Console.ReadLine());
                    Console.Write("ISBN: ");
                    isbn = int.Parse(Console.ReadLine());
                    Console.Write("Number of copies to insert: ");
                    numberOfCopies = int.Parse(Console.ReadLine());

                    InsertBook(title, description, datePublished, publisher, genre, pages, isbn, numberOfCopies);
                    Console.WriteLine("Book inserted.");
                }
                else if (userInput.Contains("insertauthor"))
                {
                    string firstName, lastName;
                    int yearBorn, yearDied;
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Write("Year born: ");
                    yearBorn = int.Parse(Console.ReadLine());
                    Console.Write("Year died(leave empty if author is still alive): ");
                    yearDied = int.Parse(Console.ReadLine());

                    InsertAuthor(firstName, lastName, yearBorn, yearDied);
                    Console.WriteLine("Author successfully inserted!");
                }
                else if (userInput.Contains("addbookauthorpair"))
                {
                    AddBookAuthorPair();
                    Console.WriteLine("Succefully paired!");
                }
                else if (userInput.Contains("addspecificbookauthorpair"))
                {
                    int bookID, authorID;
                    Console.Write("BookID: ");
                    bookID = int.Parse(Console.ReadLine());
                    Console.Write("AuthorID: ");
                    authorID = int.Parse(Console.ReadLine());

                    AddBookAuthorPair(bookID, authorID);
                    Console.WriteLine("Successfully paired!");
                }
                else if (userInput.Contains("getallthebooks"))
                {
                    foreach (var book in GetAllBooksAlphabetically())
                    {
                        Console.WriteLine(book);
                    }
                }
                else if (userInput.Contains("getallbooksbyauthor"))
                {
                    foreach (var book in GetAllBooksSortedByAuthor())
                    {
                        Console.WriteLine(book);
                    }
                }
                else if (userInput.Contains("getallbooksbygenre"))
                {
                    foreach (var book in GetAllBooksSortedByGenre())
                    {
                        Console.WriteLine(book);
                    }
                }
                else if (userInput.Contains("getallgenresfromauthor"))
                {
                    Console.Write("AuthorID: ");
                    int authorID = int.Parse(Console.ReadLine());
                    foreach (var book in GetAllGenresForAnAuthor(authorID))
                    {
                        Console.WriteLine(book);
                    }
                }
                else if (userInput.Contains("getbooksbyauthorid"))
                {
                    Console.Write("AuthorID: ");
                    int authorID = int.Parse(Console.ReadLine());
                    foreach (var book in GetAllBooksByAuthor(authorID))
                    {
                        Console.WriteLine(book);
                    }
                }
                else if (userInput.Contains("getbooksbyauthorname"))
                {
                    string firstName, lastName;
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    foreach (var book in GetAllBooksByAuthor(firstName, lastName))
                    {
                        Console.WriteLine(book);
                    }
                }
                else if (userInput.Contains("getbookinforbyisbn"))
                {
                    Console.Write("Book ISBN: ");
                    int isbn = int.Parse(Console.ReadLine());
                    GetInfoAboutBook(isbn);
                }
                else if (userInput.Contains("getbookinfobytitle"))
                {
                    Console.Write("Book title: ");
                    string title = Console.ReadLine();
                    GetInfoAboutBookByName(title);
                }
                else if (userInput.Contains("loanbook"))
                {
                    int bookID, userID;
                    string dateGiven, dateReturn;
                    Console.Write("BookID: ");
                    bookID = int.Parse(Console.ReadLine());
                    Console.Write("UserID: ");
                    userID = int.Parse(Console.ReadLine());
                    Console.Write("Date given: ");
                    dateGiven = Console.ReadLine();
                    Console.Write("Date to return: ");
                    dateReturn = Console.ReadLine();

                    LoanBookToUser(bookID, userID, DateTime.Parse(dateGiven), DateTime.Parse(dateReturn));
                }
                else if (userInput.Contains("returnbook"))
                {
                    int bookID, userID;
                    Console.Write("UserID: ");
                    userID = int.Parse(Console.ReadLine());
                    Console.Write("BookID: ");
                    bookID = int.Parse(Console.ReadLine());

                    ReturnBook(userID, bookID);
                }
                else if (userInput.Contains("/help"))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    PrintHelp();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (userInput.Contains("exit"))
                    continueRunning = false;
                else
                    Console.WriteLine("Invalid command! Write /help for the full list of commands.");
            }
        }

        static void InsertBook(string title, string description, string datePublished, string publisher, string genre, int pages, int isbn, int numberOfCopies)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var listOfBooks = connection.Books;

                foreach (var book in listOfBooks)
                    if (book.Title == title)
                        throw new BookAlreadyInDatabaseException();

                foreach (var book in listOfBooks)
                    if (book.ISBN == isbn)
                        throw new BookISBNAlreadyExistsInDatabaseException();

                if (description == "")
                    description = null;
                Book bookToAdd = new Book() { Title = title, Description = description, Date_Published = DateTime.Parse(datePublished), Publisher = publisher, Genre = genre, Pages = pages, ISBN = isbn, Number_of_copies = numberOfCopies };
                
                connection.Books.InsertOnSubmit(bookToAdd);
                connection.SubmitChanges();
            }
        }

        static void InsertAuthor(string firstName, string lastName, int yearBorn, int yearDied)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                Author authorToAdd = new Author() { First_Name = firstName, Last_Name = lastName, Year_Born = yearBorn, Year_Died = yearDied };

                connection.Authors.InsertOnSubmit(authorToAdd);
                connection.SubmitChanges();
            }
        }

        static void AddBookAuthorPair() // gets the last added book/author pair and adds their IDs to the BookAuthor table 
        {
            int bookIDToAdd, authorIDToAdd;
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var listOfBookIDs = from book in connection.Books
                                    select book.BookID;

                var listOfAuthorIDs = from author in connection.Authors
                                      select author.AuthorID;

                bookIDToAdd = listOfBookIDs.Max();
                authorIDToAdd = listOfAuthorIDs.Max();

                connection.AddBookAuthorRecord(bookIDToAdd, authorIDToAdd);
            }
        }   

        static void AddBookAuthorPair(int bookID, int authorID) // when we know the exact bookID and authorID we use this method
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                connection.AddBookAuthorRecord(bookID, authorID);
            }
        }

        static List<string> GetAllBooksAlphabetically()
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var books = from book in connection.Books
                            orderby book.Title
                            select book.Title;
                return books.ToList();
            }
        }

        static List<string> GetAllBooksSortedByAuthor()
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var books = from book in connection.Books
                            join bookAuthor in connection.BookAuthors on book.BookID equals bookAuthor.BookID
                            join author in connection.Authors on bookAuthor.AuthorID equals author.AuthorID
                            orderby author.First_Name ascending
                            select book.Title;

                return books.ToList();                
            }
        }

        static List<string> GetAllBooksSortedByGenre()
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var books = from book in connection.Books
                            orderby book.Genre
                            select book.Title;

                return books.ToList();
            }
        }

        static List<string> GetAllGenresForAnAuthor(int authorID)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var genres = from author in connection.Authors
                             join bookAuthor in connection.BookAuthors on author.AuthorID equals bookAuthor.AuthorID
                             join book in connection.Books on bookAuthor.BookID equals book.BookID
                             where author.AuthorID == authorID
                             select book.Genre;

                return genres.ToList();
            }
        }

        static List<string> GetAllGenresForAnAuthor(string authorFirstName, string authorLastName)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var genres = from author in connection.Authors
                             join bookAuthor in connection.BookAuthors on author.AuthorID equals bookAuthor.AuthorID
                             join book in connection.Books on bookAuthor.BookID equals book.BookID
                             where author.First_Name == authorFirstName && author.Last_Name == authorLastName
                             select book.Genre;

                return genres.ToList();
            }
        }

        static List<string> GetAllBooksByAuthor(int authorID)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var books = from author in connection.Authors
                            join bookAuthor in connection.BookAuthors on author.AuthorID equals bookAuthor.AuthorID
                            join book in connection.Books on bookAuthor.BookID equals book.BookID
                            where author.AuthorID == authorID
                            select book.Title;

                return books.ToList();
            }
        }

        static List<string> GetAllBooksByAuthor(string authorFirstName, string authorLastName)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var books = from author in connection.Authors
                            join bookAuthor in connection.BookAuthors on author.AuthorID equals bookAuthor.AuthorID
                            join book in connection.Books on bookAuthor.BookID equals book.BookID
                            where author.First_Name == authorFirstName && author.Last_Name == authorLastName
                            select book.Title;

                return books.ToList();
            }
        }

        static void GetInfoAboutBook(int isbn)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var listOfISBNs = (from Book in connection.Books
                                   select Book.ISBN).ToList();

                var listOfBooks = (from bookAuthor in connection.BookAuthors
                                         select bookAuthor.BookID).ToList();

                var listOfAuthors = (from Author in connection.Authors
                                     select Author.AuthorID).ToList();

                if(!listOfISBNs.Contains(isbn))
                    throw new ISBNDoesNotExistException();

                Book book = connection.Books.Single(x => x.ISBN == isbn);


                if(!listOfBooks.Contains(book.BookID))
                    throw new NoBookAuthorPairException();

                int authorID = connection.BookAuthors.Single(x => x.BookID == book.BookID).AuthorID;

                if (!listOfAuthors.Contains(authorID))
                    throw new MissingAuthorException();

                Author author = connection.Authors.Single(x => x.AuthorID == authorID);

                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Description: {book.Description}");
                Console.WriteLine($"Date published: {book.Date_Published.ToString("yyyy MMMM dd")}");
                Console.WriteLine($"Publisher: {book.Publisher}");
                Console.WriteLine($"Genre: {book.Genre}");
                Console.WriteLine($"Pages: {book.Pages}");
                Console.WriteLine($"ISBN: {book.ISBN}\n");

                Console.WriteLine($"Author first name: {author.First_Name}");
                Console.WriteLine($"Author last name: {author.Last_Name}");
                Console.WriteLine($"Year born: {author.Year_Born}");
                Console.WriteLine($"Year died: {author.Year_Died}");
            }
        }

        static void GetInfoAboutBookByName(string title)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var listOfBooks = from book in connection.Books
                                  where book.Title.Contains(title)
                                  select book;

                Book bookToGet = listOfBooks.First();
                GetInfoAboutBook(bookToGet.ISBN);
            }
        }

        static void InsertUser(string firstName, string lastName, string pseudonim, string email, int phone)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                if (pseudonim == "")
                    pseudonim = null;
                if (email == "")
                    email = null;

                User userToAdd = new User() { First_Name = firstName, Last_Name = lastName, Pseudonim = pseudonim, Email = email, Phone = phone, Books_lent = 0 };
                connection.Users.InsertOnSubmit(userToAdd);
                connection.SubmitChanges();
            }
        }

        static void LoanBookToUser(int bookID, int userID, DateTime dateGiven, DateTime dateReturn)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var listOfBooks = (from book in connection.Books
                                  select book.BookID).ToList();

                if(!listOfBooks.Contains(bookID))
                    throw new BookNotExistantException();

                var listOfUsers = (from user in connection.Users
                                   select user.UserID).ToList();

                if (!listOfUsers.Contains(userID))
                    throw new UserNotExistantException();

                int numberOfBookCopies = (from book in connection.Books
                                         where book.BookID == bookID
                                         select book.Number_of_copies).SingleOrDefault();

                int numberOfBookCopiesLoaned = (from book in connection.UserBooks
                                              where book.BookID == bookID
                                              select book).Count();

                if (numberOfBookCopiesLoaned >= numberOfBookCopies)
                {
                    Console.WriteLine("No copies left.");
                    return;
                }

                if(connection.Users.Where(x => x.UserID == userID).FirstOrDefault().Books_lent >= 5)
                {
                    Console.WriteLine("This user has already been given 5 books. No more books can be loaned until some are returned.");
                    return;
                }

                connection.Users.Where(x => x.UserID == userID).FirstOrDefault().Books_lent++;
                connection.AddUserBookRecord(bookID, userID, numberOfBookCopiesLoaned + 1, dateGiven, dateReturn);
                connection.SubmitChanges();
            }
            Console.WriteLine("Book successfully loaned.");
        }

        static void ReturnBook(int userID, int bookID)
        {
            using (BookDatabaseDataContext connection = new BookDatabaseDataContext())
            {
                var listOfBooks = (from book in connection.Books
                                   select book.BookID).ToList();

                var listOfUsers = (from user in connection.Users
                                   select user.UserID).ToList();

                if (!listOfBooks.Contains(bookID))
                    throw new BookNotExistantException();

                if (!listOfUsers.Contains(userID))
                    throw new UserNotExistantException();


                var listOfUserBookPairs = (from userBook in connection.UserBooks
                                           select userBook.BookID).ToList();

                if (!listOfUserBookPairs.Contains(bookID))
                    throw new UserBookPairNotExistantException();

                var listOfUsersWhoHaveThisBook = (from userbook in connection.UserBooks
                                                  where userbook.BookID == bookID
                                                  select userbook.UserID).ToList();

                if (!listOfUsersWhoHaveThisBook.Contains(userID))
                    throw new UserHasNotBeenGivenThisBookException();

                connection.Users.Where(x => x.UserID == userID).FirstOrDefault().Books_lent--;
                connection.RemoveUserBookRecord(userID, bookID);
                connection.SubmitChanges();
            }
            Console.WriteLine("Book successfully returned.");
        }

        static void PrintHelp()
        {
            Console.Write(new string('-', Console.WindowWidth));
            Console.WriteLine("insertbook - inserts book in the database");
            Console.WriteLine("insertauthor - inserts author in the database");
            Console.WriteLine("addbookauthorpair - sets the last inserted author as the author of the last inserted book");
            Console.WriteLine("addspecificbookauthorpair - sets the author of a book by specific authorID and bookID");
            Console.WriteLine("getallthebooks - returns a list of all the books(alphabetically ordered)");
            Console.WriteLine("getallbooksbyauthor - returns a list of the books(ordered by author name)");
            Console.WriteLine("getallbooksbygenre - returns a list of the books(ordered by genre)");
            Console.WriteLine("getallgenresfromauthor - given an authorID, returns a list of all genres the author has written");
            Console.WriteLine("getbooksbyauthorid - given an authorID, returns all the books written by the author");
            Console.WriteLine("getbooksbyauthorname - given an author's first and last name, returns all the books he's written");
            Console.WriteLine("getbookinfobyisbn - given a book ISBN, returns all the available info about the book");
            Console.WriteLine("getbookinfobytitle - given a book title, returns all the available info about the book");
            Console.WriteLine("loanbook - loans a book to a user");
            Console.WriteLine("returnbook - returns a book");
            Console.WriteLine("/help - prints the full list of commands");
            Console.WriteLine("exit - exits the application");
            Console.WriteLine(new string('-', Console.WindowWidth));
        }
    }
}