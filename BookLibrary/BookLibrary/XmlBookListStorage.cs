using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BookLibrary.SingleLogger;

namespace BookLibrary
{
    /// <summary>
    /// This class provides basic read/write to XML file operations.
    /// </summary>
    public sealed class XmlBookListStorage : IBookListStorage
    {
        #region Constructors
        /// <summary>
        /// Constructor with parameters which initializes path to the storage.
        /// </summary>
        /// <param name="fileName">Name of file which will be represent a storage.</param>
        public XmlBookListStorage(string fileName)
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

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".xml");

            if (File.Exists(path))
            {
                log.Error($"The file with given name already exists. Path to this existing file: {path}.");
                throw new ArgumentException("File with the same name already exist.");
            }

            log.Info($"Created path for storage file: {path}.");
        }
        #endregion

        public List<Book> LoadBooks()
        {
            throw new NotImplementedException();
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
                
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", null),
                new XComment($"Created by Ilia Valchenko. Date: {DateTime.Now.ToShortDateString()}"),
                new XElement("Books",
                    from book in books 
                    select new XElement("Book",
                        new XElement("Author", book.Author),
                        new XElement("Title", book.Title),
                        new XElement("Publishdate", book.ToString()),
                        new XElement("Price", book.Price))));

            xDoc.Save(path);
        }

        #region Private fields
        /// <summary>
        /// Full path to the file which represents a storage.
        /// </summary>
        private readonly string path;
        #endregion
    }
}
