using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace ConsoleApplication
{
    class Program
    {
        

       
   

        static void Main(string[] args)
        {
            /*var originalArray = new List<Book>()
            { 
                new Book("Arkady and Boris Strugatsky", "Hard to Be a God", "10-03-1989", 1.32),
                new Book("James Fenimore Cooper", "The Last of the Mohicans", "02-06-1826", 0.52),
                new Book("Valentin Pikul", "Ocean patrol", "07-08-1954", 3.01),
                new Book("Jon Skeet", "C# in Depth", "20-03-2010", 12.80),
                new Book()
            };

            var storage = new BinaryBookListStorage("storage.bin");

            storage.SaveBooks(originalArray);
            
            // Create a new collection of books.
            var otherBooks = new List<Book>
            {
                new Book("Joanne Rowling", "Harry Potter", "20-06-2010", 15.73)
            };

            // Declare a new storage with the same path.
            var newStorage = new BinaryBookListStorage("storage.bin");

            // Add new books to the existing storage.
            newStorage.SaveBooks(otherBooks);
            
            Console.WriteLine("LOADING BOOKS:" + Environment.NewLine);
            foreach (Book book in storage.LoadBooks())
                Console.WriteLine(book + Environment.NewLine);*/

            var s = new BookListService();

            s.SortByTag(CustomComparator);

            Console.WriteLine(Environment.NewLine + "Tap to continue...");
            Console.ReadKey(true);
        }

        public static int CustomComparator(Book x, Book y)
        {
            if (x.Price == y.Price)
                return 0;

            if (x.Price > y.Price)
                return 1;

            return -1;
        }
    }
}
