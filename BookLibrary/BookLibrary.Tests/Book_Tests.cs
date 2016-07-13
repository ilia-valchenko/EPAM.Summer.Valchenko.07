using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BookLibrary.Tests
{
    [TestClass]
    public class Book_Tests
    {
        [TestMethod]
        public void TestSortingByAscendingAuthor()
        {
            Book[] originalArray = 
            {
                new Book(),
                new Book("Arkady and Boris Strugatsky", "Hard to Be a God", "10-03-1989", 1.32), 
                new Book("James Fenimore Cooper", "The Last of the Mohicans", "02-06-1826", 0.52), 
                new Book("Valentin Pikul", "Ocean patrol", "07-08-1954", 3.01), 
                new Book("Jon Skeet", "C# in Depth", "20-03-2010", 12.80)
            };

            Book[] expectedArray =
            {
                new Book("Arkady and Boris Strugatsky", "Hard to Be a God", "10-03-1989", 1.32),
                new Book("James Fenimore Cooper", "The Last of the Mohicans", "02-06-1826", 0.52),
                new Book("Jon Skeet", "C# in Depth", "20-03-2010", 12.80),
                new Book(),
                new Book("Valentin Pikul", "Ocean patrol", "07-08-1954", 3.01),              
            };

            Book.Sort(originalArray, new CompareByAscendingAuthor());

            Assert.IsTrue(IsEqualBookArrays(originalArray, expectedArray));
        }

        static bool IsEqualBookArrays(Book[] arr, Book[] brr)
        {
            if(arr.Length == 0 || brr.Length == 0 || arr.Length != brr.Length)
                throw new ArgumentException("Array can't be empty or has another dimension then another one.");

            for(int i = 0; i < arr.Length; i++)
                if (!arr[i].Equals(brr[i]))
                    return false;

            return true;
        }
    }
}
