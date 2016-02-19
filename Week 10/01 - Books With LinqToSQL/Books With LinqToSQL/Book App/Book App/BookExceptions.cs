using System;
using System.Runtime.Serialization;

namespace Book_App
{
    public class BookAlreadyInDatabaseException : ApplicationException
    {
        public BookAlreadyInDatabaseException() : base ("ERROR: Book already in the database!") { }

        public BookAlreadyInDatabaseException(string message) : base(message) { }

        public BookAlreadyInDatabaseException(string message, Exception innerException) : base(message, innerException) { }

        protected BookAlreadyInDatabaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class BookISBNAlreadyExistsInDatabaseException : ApplicationException
    {
        public BookISBNAlreadyExistsInDatabaseException() : base ("ERROR: There's already a book with the same ISBN in the database!") { }

        public BookISBNAlreadyExistsInDatabaseException(string message) : base(message) { }

        public BookISBNAlreadyExistsInDatabaseException(string message, Exception innerException) : base(message, innerException) { }

        protected BookISBNAlreadyExistsInDatabaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class ISBNDoesNotExistException : ApplicationException
    {
        public ISBNDoesNotExistException() : base ("ERROR: ISBN does not exist!") { }

        public ISBNDoesNotExistException(string message) : base(message) { }

        public ISBNDoesNotExistException(string message, Exception innerException) : base(message, innerException) { }

        protected ISBNDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class NoBookAuthorPairException : ApplicationException
    {
        public NoBookAuthorPairException() : base("ERROR: There's no author/book link in the database!") { }

        public NoBookAuthorPairException(string message) : base(message) { }

        public NoBookAuthorPairException(string message, Exception innerException) : base(message, innerException) { }

        protected NoBookAuthorPairException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class MissingAuthorException : ApplicationException
    {
        public MissingAuthorException() : base("ERROR: Missing author in the database!") { }

        public MissingAuthorException(string message) : base(message) { }

        public MissingAuthorException(string message, Exception innerException) : base(message, innerException) { }

        protected MissingAuthorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class BookNotExistantException : ApplicationException
    {
        public BookNotExistantException() : base("ERROR: Missing book in the database!") { }

        public BookNotExistantException(string message) : base(message) { }

        public BookNotExistantException(string message, Exception innerException) : base(message, innerException) { }

        protected BookNotExistantException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class UserNotExistantException : ApplicationException
    {
        public UserNotExistantException() : base("ERROR: User does not exist!") { }

        public UserNotExistantException(string message) : base(message) { }

        public UserNotExistantException(string message, Exception innerException) : base(message, innerException) { }

        protected UserNotExistantException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class UserBookPairNotExistantException : ApplicationException
    {
        public UserBookPairNotExistantException() : base("ERROR: UserBook pair not existant!") { }

        public UserBookPairNotExistantException(string message) : base(message) { }

        public UserBookPairNotExistantException(string message, Exception innerException) : base(message, innerException) { }

        protected UserBookPairNotExistantException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class UserHasNotBeenGivenThisBookException : ApplicationException
    {
        public UserHasNotBeenGivenThisBookException() : base("ERROR: This book has not been given to that user!") { }

        public UserHasNotBeenGivenThisBookException(string message) : base(message) { }

        public UserHasNotBeenGivenThisBookException(string message, Exception innerException) : base(message, innerException) { }

        protected UserHasNotBeenGivenThisBookException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}