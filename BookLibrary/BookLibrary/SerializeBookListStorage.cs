using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static BookLibrary.SingleLogger;

namespace BookLibrary
{
    /// <summary>
    /// This class provides basic read/write operations for collection of books by using serialize technology.
    /// </summary>
    public sealed class SerializeBookListStorage : IBookListStorage
    {
        #region Constructors
        /// <summary>
        /// Constructor with parameters which initializes path to the storage.
        /// </summary>
        /// <param name="fileName">Name of file which will be represent a storage.</param>
        public SerializeBookListStorage(string fileName)
        {
            if (fileName == null || fileName.Equals(string.Empty))
            {
                log.Error("Attempt to create a storage file with empty or null name.");
                throw new ArgumentException("Filename can't be empty.");
            }

            if (!new System.Text.RegularExpressions.Regex(@"^[\w\-. ]+$").IsMatch(fileName))
            {
                log.Error($"Attempt to create a file by wrong filename. Filename: {fileName}.");
                throw new ArgumentException("Name of file is not valid.");
            }

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".dat");

            if (File.Exists(path))
            {
                log.Error($"The file with given name already exists. Path to this existing file: {path}.");
                throw new ArgumentException("File with the same name already exist.");
            }

            log.Info($"Created path for storage file: {path}.");
        }
        #endregion

        /// <summary>
        /// This method reads books from a file.
        /// </summary>
        /// <returns>Returns collection of books.</returns>
        public List<Book> LoadBooks()
        {
            if (!File.Exists(path))
            {
                log.Error($"Attempt to read from a non-existing file. Path: {path}.");
                throw new FileNotFoundException($"File by given path doesn't exist. Path: {path}.");
            }

            using (var stream = File.Open(path, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                return (List<Book>)bformatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// This method saves the given collection of books into the file.
        /// </summary>
        /// <param name="books">Collection of books which will be saved into the file.</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            if (books == null)
            {
                log.Error($"Attempt to save list of books which is null into a XML. Path: {path}.");
                throw new ArgumentNullException(nameof(books));
            }

            using (var stream = File.Open(path, FileMode.CreateNew))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, books);
            }
        }

        #region Private fields
        /// <summary>
        /// Full path to the file which represents a storage.
        /// </summary>
        private readonly string path;
        #endregion
    }
}
