using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookLibrary
{
    class BinaryBookListStorage : IBookListStorage
    {
        public BinaryBookListStorage(string fileName)
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".txt");

            try
            {
                if (File.Exists(path))
                    File.Delete(path);

                fileStream = File.Create(path);
            }
            catch (Exception exc)
            {
                // logger here
            }
        }

        public List<Book> LoadBooks()
        {
            throw new NotImplementedException();
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException("Something happened with textfile.");

            //var binaryWriter = new BinaryWriter(fileStream);
            XmlSerializer formatter = new XmlSerializer(typeof(Book));
            formatter.Serialize(fileStream, books);
        }

        private readonly string path;
        private readonly FileStream fileStream;
    }
}
