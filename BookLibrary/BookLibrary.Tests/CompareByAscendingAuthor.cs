using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Tests
{
    public class CompareByAscendingAuthor : IComparer<Book>
    {
        public int Compare(Book x, Book y) => string.Compare(x.Author, y.Author);
    }
}
