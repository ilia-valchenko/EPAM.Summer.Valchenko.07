using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// This class represents a book which has properties such as name of author, title of the book, publish date and price.
    /// </summary>
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>, IEnumerable<Book>, IEnumerator<Book>
    {
        #region Public properties

        /// <summary>
        /// This property returns name the author of the book.
        /// </summary>
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                var r = new Regex(@"^[A-Za-z\s]*$");
                if (r.IsMatch(value))
                    author = value;
            }
        }

        /// <summary>
        /// This property returns title of the book.
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                //Regex r = new Regex(@"(?<=\d\s)([a-zA-Z]+\s)*[a-zA-Z]+");
                //if (r.IsMatch(value))
                    title = value;
            }
        }

        /// <summary>
        /// This property returns book's publish day.
        /// </summary>
        public DateTime PublishDate
        {
            get
            {
                return publishDate;
            }
            set
            {
                if(value > DateTime.Now)
                    throw new ArgumentException("Publish date can't be later than now.");

                publishDate = value;
            }
        }

        /// <summary>
        /// This property returns price of the book.
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if(value < 0)
                    throw new ArgumentException("Price of book can't be less than zero.");

                price = value;
            }
        }

        public Book Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor which calls another constructor with parameters.
        /// </summary>
        public Book() : this("Unknown", "Untitled", DateTime.Now.ToShortTimeString(), 00.00) { }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="authorName">Name the author of the book.</param>
        /// <param name="bookTitle">Title of the book.</param>
        /// <param name="bookPublishDate">Book's publish day.</param>
        /// <param name="bookPrice">Price of the book.</param>
        public Book(string authorName, string bookTitle, string bookPublishDate, double bookPrice)
        {
            Author = authorName;
            Title = bookTitle;
            DateTime bufferPublishDate;
            DateTime.TryParse(bookPublishDate, out bufferPublishDate);
            PublishDate = bufferPublishDate;
            Price = bookPrice;
        }

        #endregion

        #region Implemented and overridden methods
        /// <summary>
        /// This method compares current book to another one. Returns true if they are the same.
        /// </summary>
        /// <param name="other">Another book for comparison.</param>
        /// <returns>Returns true if they are the same. Returns false if the aren't equal.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (string.Compare(author.ToUpper(), other.author.ToUpper(), StringComparison.CurrentCulture) == 0)
                if (string.Compare(title.ToUpper(), other.title.ToUpper(), StringComparison.CurrentCulture) == 0)
                    if (publishDate.Equals(other.publishDate))
                        if (price.Equals(other.price))
                            return true;

            return false;
        }

        /// <summary>
        /// This method compares current book and another object. If object can be cast to Book type then calls Equals method with parameter type of Book.
        /// </summary>
        /// <param name="obj">Instance of Object.</param>
        /// <returns>Return false if objects aren't equal.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            return this.Equals(obj as Book);
        }

        /// <summary>
        /// This method compare current book to another one by publish date.
        /// </summary>
        /// <param name="other">Another book for comparison.</param>
        /// <returns>Returns 0 if these books were published at the same time. Returns -1 if current book was published earlier then another one.</returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
                return 1;

            if (publishDate.Equals(other.publishDate))
                return 0;

            if (publishDate < other.publishDate)
                return -1;
            
            return 1;
        }

        /// <summary>
        /// This method compare current book to an object.
        /// </summary>
        /// <param name="obj">Instance of System.Object</param>
        public int CompareTo(object obj) => this.CompareTo(obj as Book);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Book> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method returns formated string with information about book such as name the author, title of the book, book's publish date, price of the book.
        /// </summary>
        public override string ToString() => $"Author: {Author}, Title: {Title}, Publish date: {PublishDate}, Price: {Price}.";
        
        /// <summary>
        /// This method returns hash code of string which represents book instance.
        /// </summary>
        /// <returns>Returns hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return publishDate.GetHashCode() % price.GetHashCode() ^ 308;
            }
        }
        #endregion

        #region Private fileds
        /// <summary>
        /// Name the author of the book.
        /// </summary>
        private string author;

        /// <summary>
        /// Title of the book.
        /// </summary>
        private string title;

        /// <summary>
        /// Book's publish date.
        /// </summary>
        private DateTime publishDate;

        /// <summary>
        /// Price of the book.
        /// </summary>
        private double price; 
        #endregion
    }
}
