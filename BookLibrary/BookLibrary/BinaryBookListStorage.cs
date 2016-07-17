using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookLibrary
{
    /// <summary>
    /// This class manages the book store.
    /// </summary>
    public class BinaryBookListStorage : IBookListStorage
    {
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="fileName">Name of file which will be represent a storage.</param>
        public BinaryBookListStorage(string fileName)
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".txt");

            try
            {
                if (File.Exists(path))
                    File.Delete(path);

                fileStream = File.Create(path);
            }
            catch (Exception exc)
            {
                // logger here
            }
        }

        /// <summary>
        /// This method loads books from the storage.
        /// </summary>
        /// <returns></returns>
        public List<Book> LoadBooks()
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (List<Book>)bformatter.Deserialize(fileStream);
        }

        /// <summary>
        /// This method saves books into the storage.
        /// </summary>
        /// <param name="books">List of books which will be stored.</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Something happened with textfile.");

            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            foreach (Book book in books)
               bformatter.Serialize(fileStream, book);
        }

        /// <summary>
        /// This method saves one book into the storage.
        /// </summary>
        /// <param name="book">Book which must be stored.</param>
        public void SaveBook(Book book) => SaveBooks(new Book[] {book});

        /// <summary>
        /// Full path to the file which represents storage.
        /// </summary>
        private readonly string path;
        /// <summary>
        /// Stream for operations.
        /// </summary>
        private readonly FileStream fileStream;
    }
}
