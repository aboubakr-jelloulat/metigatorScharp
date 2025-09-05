using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;


namespace System_Advanced._00_Stream
{
    class CurrencyService : IDisposable
    {
        private readonly HttpClient httpClient;
        bool _disposed = false;
        public CurrencyService()
        {
            httpClient = new HttpClient();
        }


        // disposing = true => dispose managed + unmanaged 
        // disposing = false => dispose unmanaged + large fields
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                
                httpClient.Dispose();    // dispose managed

            }
            // unmanged object + set large fields with NULL


            _disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            // hna kat9olo mli user dar dipose bla mat3iet l constarctor bash mykonchi 2 dipose
            // dispose is called 100%  
            GC.SuppressFinalize(this);
        }

        public string GetCurrencies()
        {
            string url = "https://coinbase.com/api/v2/currencies";

            var result = httpClient.GetStringAsync(url).Result;

           

            return (result);
        }


        ~CurrencyService() // ila user Nssa ma3itchi l dipose f using()
        {
            Dispose(false);
        }
    }

    public class stream
    {


        static void ImplementIDisposablePattern()
        {
            // 1) - Not Recommanded

            //CurrencyService currencyService = new CurrencyService();

            //var result = currencyService.GetCurrencies();

            //currencyService.Dispose();

            //Console.WriteLine(result);



            // 2) - Recommanded

            //CurrencyService currencyService = null;
            //try
            //{
            //    currencyService = new CurrencyService();

            //    var result = currencyService.GetCurrencies();


            //    Console.WriteLine(result);

            //}
            //catch
            //{
            //    Console.WriteLine("Error");
            //}
            //finally
            //{

            //    currencyService?.Dispose();
            //}


            // 3 ) -  using() More Recommanded  using .Net framwork 2+


            //using by default call Depose !!!you don't need to call it
            using (CurrencyService currencyService = new CurrencyService())
            {
                var result = currencyService.GetCurrencies();


                Console.WriteLine(result);

            }



            // 4 ) -   using() with no block  c# 8.0 Ana ma3ndich hahahahhahaha


            //using CurrencyService currencyService = new CurrencyService();

            //var result = currencyService.GetCurrencies();


            // Console.WriteLine(result);



        }

        static void FstreamBascis()
        {
            string path = "C:\\Users\\HP\\Desktop\\File1.txt.txt";

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.WriteLine($"Length: {fs.Length} Byte(s)");
                Console.WriteLine($"CanRead: {fs.CanRead}");
                Console.WriteLine($"CanWrite: {fs.CanWrite}");
                Console.WriteLine($"CanSeek: {fs.CanSeek}");
                Console.WriteLine($"CanTimeout: {fs.CanTimeout}");
                Console.WriteLine($"Position: {fs.Position}");

                // Write a single byte (65 = ASCII 'A')
                fs.WriteByte(65);

                // Show new position
                Console.WriteLine($"Position: {fs.Position}");

                fs.WriteByte(66);
                fs.WriteByte(13); // Enter


                for (byte i = 65; i <= 122; i++)
                {
                    fs.WriteByte(i);
                }
            }
        }

        static void FstreamBuffer()
        {
            string path = "C:\\Users\\HP\\Desktop\\File1.txt.txt";

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] buffer = new byte[fs.Length];

                int numBytesToRead = (int)fs.Length;

                int numBytesRead = 0;

                while (numBytesToRead > 0)
                {
                    int n = fs.Read(buffer, 0, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesToRead -= n;

                    numBytesRead += n;
                }

                foreach (var item in buffer)
                {
                    Console.WriteLine((char)item);
                }

            }
        }



        static void fstreamWriteInAnotherFile()
        {
            string path = "C:\\Users\\HP\\Desktop\\File1.txt.txt";

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] buffer = new byte[fs.Length];

                int numBytesToRead = (int)fs.Length;

                int numBytesRead = 0;

                while (numBytesToRead > 0)
                {
                    int n = fs.Read(buffer, 0, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesToRead -= n;

                    numBytesRead += n;
                }



                string NewFilePath = "C:\\Users\\HP\\Desktop\\File2.txt";

                using (var fs2 = new FileStream(NewFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fs2.Write(buffer, 0, buffer.Length);
                }

            }
        }

        static void TestSeek()
        {
            string path = "C:\\Users\\HP\\Desktop\\FileSeek2.txt";

            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Seek(20, SeekOrigin.Begin);

                fs.WriteByte(65);

                fs.Position = 0;

                for (global::System.Int32 i = 0; i < fs.Length; i++)
                {
                    Console.WriteLine(fs.ReadByte());
                }
            }
        }



        static void FileStream()
        {
            //FstreamBascis();

            //FstreamBuffer();

            //fstreamWriteInAnotherFile();

            TestSeek();

        }


        private static void StreamReaderStreamWriter()
        {
            string path = "C:\\Users\\HP\\Desktop\\FileAdapter1.txt";


            Console.WriteLine("Write ... \n");
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("Hej !");
                sw.WriteLine("This is C#");
            }

            Console.WriteLine("Read ... \n\n");

            // 1 **


            //using(var sr = new StreamReader(path))
            //{
            //    while(sr.Peek() > 0)
            //    {
            //        Console.Write((char)sr.Read());
            //    }
            //}

            // 2 ***

            using (var sr = new StreamReader(path))
            {
                string line = "";

                while ((line = sr.ReadLine())  != null)
                {
                    Console.WriteLine(line);
                }
            }


        }



        static void FileFacadeOperations()
        {
            //  ******** Write Lines ********



            //string path = "C:\\Users\\HP\\Desktop\\FileFacade1.txt";

            //string[] lines =
            //{
            //    "C#",
            //    "Is",
            //    "Amazing !"

            //};

            //File.WriteAllLines(path, lines);



            //  ******** Write Text ********


            //string path = "C:\\Users\\HP\\Desktop\\FileFacade2.txt";

            //string text = "Hej ! This is Text ...";


            //File.WriteAllText(path, text);




            //  ******** Read Text ********



            //string path = "C:\\Users\\HP\\Desktop\\FileFacade2.txt";

            //var result = File.ReadAllText(path);

            //Console.WriteLine(result);



            //  ******** Read Lines ********

            string path = "C:\\Users\\HP\\Desktop\\FileAdapter1.txt";

            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

        }


        static void Decorator()
        {
            // Create a file and write compressed data
            using (var fileStream = File.Create("data.bin"))
            {
                using (var compressionStream = new DeflateStream(fileStream, CompressionMode.Compress))
                {
                    compressionStream.WriteByte(65); // Writes 'A'
                    compressionStream.WriteByte(66); // Writes 'B'
                }
            }

            // Read the compressed file and decompress it
            using (var fileStream = File.OpenRead("data.bin"))
            {
                using (var decompressionStream = new DeflateStream(fileStream, CompressionMode.Decompress))
                {
                    int b;
                    while ((b = decompressionStream.ReadByte()) != -1) // Read until end of stream
                    {
                        Console.WriteLine(b); // Output: 65, 66
                    }
                }
            }

        }



        public static void TestStream()
        {

            //ImplementIDisposablePattern();


            //FileStream();


            //StreamReaderStreamWriter();


            //FileFacadeOperations();



            Decorator();

        }

    }
}
