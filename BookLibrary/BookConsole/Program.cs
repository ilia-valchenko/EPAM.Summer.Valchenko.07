using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using BookLibrary.Tests;

namespace BookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book(),
                new Book("Arkady and Boris Strugatsky", "Hard to Be a God", "10-03-1989", 1.32),
                new Book("James Fenimore Cooper", "The Last of the Mohicans", "02-06-1826", 0.52),
                new Book("Valentin Pikul", "Ocean patrol", "07-08-1954", 3.01),
                new Book("Jon Skeet", "C# in Depth", "20-03-2010", 12.80)
            };

            Console.WriteLine("Original array:\n");
            PrintBookArray(books);

            Console.WriteLine("\nSorted array:\n");
            Book.Sort(books, new CompareByAscendingAuthor());
            PrintBookArray(books);

            Console.WriteLine("\n\nTap to continue...");
            Console.ReadKey(true);
        }

        static void PrintBookArray(Book[] books)
        {
            foreach (var VARIABLE in books)
            {
                Console.WriteLine(VARIABLE + Environment.NewLine);
            }
        }
    }
}
