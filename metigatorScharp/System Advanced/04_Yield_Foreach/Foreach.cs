using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Advanced._04_Yield_Foreach
{
    internal class Foreach
    {

        public static void ft_Foreach<T>(IEnumerable<T> source)
        {
            IEnumerator<T> enumerator = source.GetEnumerator();

            IDisposable disposable;


            try
            {
                T item;

                while (enumerator.MoveNext())
                {
                    item = enumerator.Current;

                    Console.Write(item + " ");
                }

            }
            finally
            {
                disposable = (IDisposable)enumerator;
                disposable.Dispose();
            }

        }


        public static void TestForeach()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("\n\n Using For");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($" {numbers[i]}");
            }


            Console.WriteLine("\n\n Using Foreach");
            foreach (var n in numbers)
            {
                Console.Write($" {n}");
            }


            Console.WriteLine("\n\n Using Foreach under the hood");
            ft_Foreach(numbers);


        }

    }
}
