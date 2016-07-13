using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Tests
{
    public class CompareByAscendingPrice : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Price.Equals(y.Price))
                return 0;

            if (x.Price > y.Price)
                return 1;

            return -1;
        }
    }
}
