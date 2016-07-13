using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Tests
{
    public class CompareByDescendingPublishDate : IComparer<Book>
    {
        public int Compare(Book x, Book y) => -DateTime.Compare(x.PublishDate, y.PublishDate);
    }
}
