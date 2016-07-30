using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// This class provides basic read/write operations for collection of books.
    /// </summary>
    public static class SerializationBookService
    {
        /// <summary>
        /// This method writes collection of books into a file.
        /// </summary>
        /// <param name="fileName">The file name for the record.</param>
        /// <param name="books">Collection of books which will be written into a file.</param>
        public static void SaveToFile(string fileName, IEnumerable<Book> books)
        {
            if (!new Regex(@"^[\w\-. ]+$").IsMatch(fileName))
                throw new ArgumentException("Name of file is not valid.");

            if (books == null)
                throw new ArgumentNullException(nameof(books));

            using (var stream = File.Open(fileName, FileMode.OpenOrCreate))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, books);
            }
        } 

        /// <summary>
        /// This method reads books from a file.
        /// </summary>
        /// <param name="fileName">Name of file.</param>
        /// <returns>Returns collection of books.</returns>
        public static IEnumerable<Book> ReadFromFile(string fileName)
        {
            if(!File.Exists(fileName))
                throw new FileNotFoundException($"{fileName} didn't found.");

            using (var stream = File.Open(fileName, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                return (List<Book>)bformatter.Deserialize(stream);
            }
        }
    }
}
