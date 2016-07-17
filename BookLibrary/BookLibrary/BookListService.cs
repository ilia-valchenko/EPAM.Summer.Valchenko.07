using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// This class provides basic operation with collection of books.
    /// </summary>
    public class BookListService
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BookListService()
        {
            storage = new BinaryBookListStorage("books");
        }

        /// <summary>
        /// Add book to a storage.
        /// </summary>
        /// <param name="book">Book</param>
        public void AddBook(Book book)
        {
            if(book == null)
                throw new ArgumentNullException(nameof(book));

            storage.SaveBook(book);
        }

        /// <summary>
        /// Remove book from a storage.
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            List<Book> books = storage.LoadBooks();

            if(!books.Contains(book))
                throw new ArgumentException("Book doesn't exist in a storage.");

            books.Remove(book); 
            storage.SaveBooks(books);
        }

        /// <summary>
        /// Class represents a storage for books.
        /// </summary>
        private readonly BinaryBookListStorage storage;
    }
}
