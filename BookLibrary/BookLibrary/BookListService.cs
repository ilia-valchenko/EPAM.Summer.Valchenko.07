using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.Fluent;
using static BookLibrary.SingleLogger;

namespace BookLibrary
{
    /// <summary>
    /// This class provides basic operation with collection of books.
    /// </summary>
    public class BookListService 
    {
        #region Public fields and properties
        /// <summary>
        /// This property returns read only collection of books.
        /// </summary>
        public ReadOnlyCollection<Book> Books => new ReadOnlyCollection<Book>(books);
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BookListService() : this(new List<Book>()) { }

        /// <summary>
        /// This constructor takes books as IEnumerable.
        /// </summary>
        /// <param name="books">Books as IEnumerable.</param>
        public BookListService(IEnumerable<Book> books)
        {
            if (ReferenceEquals(books, null))
            {
                log.Error("Your input book collection for BookListService constructor is null.");
                throw new ArgumentNullException(nameof(books));
            }
                
            this.books = books.ToList();
        }
        #endregion

        #region Add and Remove methods
        /// <summary>
        /// Add a book to a service.
        /// </summary>
        /// <param name="book">Book which must be added.</param>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                log.Error("Attempt to add book which is null.");
                throw new ArgumentNullException(nameof(book));
            }

            if (books.Contains(book))
            {
                log.Warn("Attempt to add book which is already exist in current list of books.");
                throw new ArgumentException("This book already exist.");
            }
                
            books.Add(book);
        }

        /// <summary>
        /// Remove book from a storage.
        /// </summary>
        /// <param name="book">The book which must be removed.</param>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                log.Error("Attempt to remove book which is null.");
                throw new ArgumentNullException(nameof(book));
            }

            if (!books.Contains(book))
            {
                log.Error("Attempt to remove book which doesn't exist in the current list.");
                throw new ArgumentException("This book doesn't exist.");
            }
                
            books.Remove(book);
        } 
        #endregion

        #region Sorting methods

        /// <summary>
        /// This method sorts list of books by using delegate Comparision.
        /// </summary>
        /// <param name="comparison">Criterion for comparison.</param>
        public void SortByTag(Comparison<Book> comparison)
        {
            if (ReferenceEquals(comparison, null))
            {
                log.Error("Delegate Comparision<Book> in SortByTag is null.");
                throw new ArgumentNullException(nameof(comparison));
            }
                               
            books.Sort(comparison);
        }

        /// <summary>
        /// This method sorts list of books by using IComparer.
        /// </summary>
        /// <param name="comparer">Criterion for comparison.</param>
        public void SortByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
            {
                log.Error("Comparer for SortByTag method is null.");
                throw new ArgumentNullException(nameof(comparer));
            }

            books.Sort(comparer);
        } 
        #endregion

        /// <summary>
        /// This method finds list of books by given tag.
        /// </summary>
        /// <returns>List of books.</returns>
        public List<Book> FindByTag(Predicate<Book> predicate)
        {
            if (ReferenceEquals(predicate, null))
            {
                log.Error("Predicate is null in FindByTag method.");
                throw new ArgumentNullException(nameof(predicate));
            }
                
            var result = new List<Book>();

            foreach (Book book in books)
                if(predicate(book))
                    result.Add(book);

            return result;
        }

        #region Private fields
        /// <summary>
        /// List of books.
        /// </summary>
        private readonly List<Book> books;
        #endregion
    }
}
