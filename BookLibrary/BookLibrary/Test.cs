using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Test
    {
        public Test()
        {
            try
            {
                if(File.Exists(listOfBooksPath))
                    File.Delete(listOfBooksPath);

                
                using (FileStream fs = File.Create(listOfBooksPath))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception exc)
            {
                
            }
        }

        private string listOfBooksPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "books.txt");
    }
}
