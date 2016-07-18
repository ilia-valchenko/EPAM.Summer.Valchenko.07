using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.Fluent;

namespace BookLibrary
{
    /// <summary>
    /// This class provides basic operation with collection of books.
    /// </summary>
    public class BookListService
    {
        #region Public fields and properties
        /// <summary>
        /// This property returns current list of books.
        /// </summary>
        public List<Book> Books { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BookListService() : this(new BinaryBookListStorage()) { }

        /// <summary>
        /// This constructor takes a BinaryBookListStorage as a parameter.
        /// </summary>
        /// <param name="storage"></param>
        public BookListService(BinaryBookListStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException(nameof(storage));    

            this.storage = storage;
            books = new List<Book>();
        }
        #endregion

        #region Add and Remove methods
        /// <summary>
        /// Add book to a storage.
        /// </summary>
        /// <param name="book">Book which must be added.</param>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (books.Contains(book))
                throw new ArgumentException("This book already exist.");

            books.Add(book);
        }

        /// <summary>
        /// Remove book from a storage.
        /// </summary>
        /// <param name="book">The book which must be removed.</param>
        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (!books.Contains(book))
                throw new ArgumentException("This book doesn't exist.");

            books.Remove(book);
        } 
        #endregion

        #region Sorting methods
        /// <summary>
        /// This method sorts list of books by using delegate Comparision.
        /// </summary>
        /// <param name="comparison">Criterion for comparison.</param>
        public void SortByTag(Comparison<Book> comparison) => books.Sort(comparison);

        /// <summary>
        /// This method sorts list of books by using IComparer.
        /// </summary>
        /// <param name="comparer">Criterion for comparison.</param>
        public void SortByTag(IComparer<Book> comparer) => books.Sort(comparer);
        #endregion

        #region SaveToStorage and LoadFromStorage methods
        /// <summary>
        /// This method saves current list of books into a storage.
        /// </summary>
        public void SaveBooksToStorage() => storage.SaveBooks(books);

        /// <summary>
        /// This method loads books from the storage into a current list of books.
        /// </summary>
        public void LoadBooksFromStorage() => books.AddRange(storage.LoadBooks()); 
        #endregion

        /// <summary>
        /// This method finds list of books by given tag.
        /// </summary>
        /// <returns>List of books.</returns>
        public List<Book> FindByTag(Func<List<Book>, List<Book>> find)
        {
            throw new NotImplementedException();
        }

        #region Private fields
        /// <summary>
        /// Class represents a storage for books.
        /// </summary>
        private readonly BinaryBookListStorage storage;
        /// <summary>
        /// List of books.
        /// </summary>
        private readonly List<Book> books;
        /// <summary>
        /// Logger for warrning and error messages.
        /// </summary>
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion
    }
}
