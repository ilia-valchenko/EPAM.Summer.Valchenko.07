using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static BookLibrary.SingleLogger;

namespace BookLibrary
{
    /// <summary>
    /// This class represents the storage of books based on binary file.
    /// </summary>
    public sealed class BinaryBookListStorage : IBookListStorage
    {
        #region Constructors
        /// <summary>
        /// Constructor with parameters which initializes path to the storage.
        /// </summary>
        /// <param name="fileName">Name of file which will be represent a storage.</param>
        public BinaryBookListStorage(string fileName)
        {
            if (fileName == null || fileName.Equals(string.Empty))
            {
                log.Error("Attempt to create a storage file with empty or null name.");
                throw new ArgumentException("Filename can't be empty.");
            }

            if (!new Regex(@"^[\w\-. ]+$").IsMatch(fileName))
            {
                log.Error($"Attempt to create a file by wrong filename. Filename: {fileName}.");
                throw new ArgumentException("Name of file is not valid.");
            }

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (File.Exists(path))
            {
                log.Error($"The file with given name already exists. Path to this existing file: {path}.");
                throw new ArgumentException("File with the same name already exist.");
            }

            log.Info($"Created path for storage file: {path}.");
        }
        #endregion

        #region Basic operations for storage
        /// <summary>
        /// This method loads books from the storage.
        /// </summary>
        /// <returns>Returns list of books which contains into the storage.</returns>
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
        /// This method saves a collection of books into the storage.
        /// </summary>
        /// <param name="books">List of books which will be stored.</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            if (books == null)
            {
                log.Error("Attemt to save a collection of books which is null.");
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
                    bWriter.Write(book.PublishDate.ToShortDateString());
                    bWriter.Write(book.Price);
                }
            }
        }
        #endregion

        #region Private fields
        /// <summary>
        /// Full path to the file which represents a storage.
        /// </summary>
        private readonly string path; 
        #endregion
    }
}
