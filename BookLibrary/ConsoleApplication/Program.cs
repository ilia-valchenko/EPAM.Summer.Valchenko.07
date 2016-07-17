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
            List<Book> originalArray = new List<Book>();
            originalArray.Add(new Book());
            originalArray.Add(new Book("Arkady and Boris Strugatsky", "Hard to Be a God", "10-03-1989", 1.32));
            originalArray.Add(new Book("James Fenimore Cooper", "The Last of the Mohicans", "02-06-1826", 0.52));
            originalArray.Add(new Book("Valentin Pikul", "Ocean patrol", "07-08-1954", 3.01));
            originalArray.Add(new Book("Jon Skeet", "C# in Depth", "20-03-2010", 12.80));

            BinaryBookListStorage storage = new BinaryBookListStorage("books");

            storage.SaveBooks(originalArray);

            Console.WriteLine(Environment.NewLine + "Tap to continue...");
            Console.ReadKey(true);
        }
    }
}
