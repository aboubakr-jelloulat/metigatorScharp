using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Advanced._04_Yield
{
    internal class Yield
    {
        static IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 2; i <= max; i += 2)
            {
                yield return i; // give one number, pause, and wait
            }
        }

        // Why not just use a List? : This builds the whole list in memory before you can use it.
        static List<int> GetEvenNumbersUsingList(int max)
        {
            List<int> result = new List<int>();
            for (int i = 2; i <= max; i += 2)
            {
                result.Add(i);
            }
            return result;
        }

        static IEnumerable<int> GetNumbers()
        {
            yield return 1;   // stops here first time
            yield return 2;   // stops here second time
            yield return 3;   // stops here third time
        }


        static IEnumerable<int> GetNumbersUntil5()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i > 5)
                    yield break; // stop completely
                yield return i;
            }
        }

        // Processing large data without storing all of it

        static IEnumerable<string> ReadFileLines(string path)
        {
            foreach (var line in System.IO.File.ReadLines(path))
            {
                yield return line;
            }
        }

        static IEnumerable<int> GetOddNumbers(IEnumerable<int> numbers)
        {
            foreach (var num in numbers)
            {
                if (num % 2 != 0)
                    yield return num;
            }
        }

        public static void TestYield()
        {
            Console.WriteLine("GetEvenNumbers (max = 10):");
            foreach (var num in GetEvenNumbers(10))
                Console.Write(num + " ");
            Console.WriteLine();

            Console.WriteLine("GetEvenNumbersUsingList (max = 10):");
            foreach (var num in GetEvenNumbersUsingList(10))
                Console.Write(num + " ");
            Console.WriteLine();

            Console.WriteLine("GetNumbers:");
            foreach (var num in GetNumbers())
                Console.Write(num + " ");
            Console.WriteLine();

            Console.WriteLine("GetNumbersUntil5:");
            foreach (var num in GetNumbersUntil5())
                Console.Write(num + " ");
            Console.WriteLine();

            Console.WriteLine("GetOddNumbers from 1 to 10:");
            var numbers = Enumerable.Range(1, 10);
            foreach (var num in GetOddNumbers(numbers))
                Console.Write(num + " ");
            Console.WriteLine();

            //Console.WriteLine("ReadFileLines (example.txt):");
            //foreach (var line in ReadFileLines("example.txt"))
            //    Console.WriteLine(line);

        }

    }
}
