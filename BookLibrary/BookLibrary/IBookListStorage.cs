using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// Interface provides two basic operation for storage of books.
    /// </summary>
    public interface IBookListStorage
    {
        /// <summary>
        /// Load book from a storage.
        /// </summary>
        /// <returns>Returns list of books.</returns>
        List<Book> LoadBooks();

        /// <summary>
        /// This method packs given books into a storage.
        /// </summary>
        /// <param name="books">Books which must be stored.</param>
        void SaveBooks(IEnumerable<Book> books);
    }
}
