using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static BookLibrary.SingleLogger;

namespace BookLibrary
{
    /// <summary>
    /// This class manages the storage of books.
    /// </summary>
    public class BinaryBookListStorage : IBookListStorage
    {
        #region Constructors
        /// <summary>
        /// Default constructor which creates the default storage 'defaultstorage.bin'.
        /// </summary>
        public BinaryBookListStorage() : this("defaultstorage.bin") { }

        /// <summary>
        /// Constructor with parameters which initializes path to the storage.
        /// </summary>
        /// <param name="fileName">Name of file which will be represent a storage.</param>
        public BinaryBookListStorage(string fileName)
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            log.Info($"Created path for log file: {path}.");
        }
        #endregion

        #region Basic operations for storage
        /// <summary>
        /// This method loads books from the storage.
        /// </summary>
        /// <returns></returns>
        public List<Book> LoadBooks()
        {
            var books = new List<Book>();

            if (File.Exists(path))
            {
                using (var bReader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (bReader.PeekChar() > -1)
                        books.Add(new Book(bReader.ReadString(), bReader.ReadString(), bReader.ReadString(),
                            bReader.ReadDouble()));
                }
            }
            else
            {
                log.Error($"Storage at the address does not exist. Wrong path: {path}.");
                throw new FileNotFoundException("This storage doesn't exist.");
            }

            return books;
        }

        /// <summary>
        /// This method saves books into the storage.
        /// </summary>
        /// <param name="books">List of books which will be stored.</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            if (ReferenceEquals(books, null))
            {
                log.Error("Attemt to save book which is null.");
                throw new ArgumentNullException(nameof(books));
            }
                
            var existingBooks = LoadBooks();
            existingBooks.AddRange(books.ToList());

            using (var bWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Book book in existingBooks)
                {
                    bWriter.Write(book.Author);
                    bWriter.Write(book.Title);
                    bWriter.Write(book.PublishDate.ToString());
                    bWriter.Write(book.Price);
                }
            }
        }
        #endregion

        #region Private fields
        /// <summary>
        /// Full path to the file which represents storage.
        /// </summary>
        private readonly string path; 
        #endregion
    }
}
