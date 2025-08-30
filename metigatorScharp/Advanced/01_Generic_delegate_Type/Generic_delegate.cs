using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;


namespace Advanced._01_Generic_delegate_Type
{
    public class Generic_delegate
    {
        //public delegate bool Filter<in T>(T nb);

        static void PrintNumber<T>(IEnumerable<T> list, Predicate<T> filter, Action action)
        {
            action();

            foreach (var nb in list)
            {
                if (filter(nb))
                    Console.WriteLine(nb);
            }
        }


        public static void TestGeneric_delegate()
        {
            // IEnumerable<int> is read-only: you can iterate but not modify directly.

            IEnumerable<int> list1 = new int[] { 2, 5, 6, 7, 9, 1, 3, 4, 8 };

 

            PrintNumber(list1, n => n < 6, () => Console.WriteLine("Number Less Than 6 : "));


            PrintNumber(list1, n => n < 7, () => Console.WriteLine("Number Less Than 7 : "));

            PrintNumber(list1, n => n % 2 == 0, () => Console.WriteLine("Even Number : "));
        }



        public static void TestGeneric_delegateFunc_Action_Predicate()
        {

                    /*
                 SUMMARY

                 - Action<T> : points to a method that TAKES T and RETURNS void.
                 - Func<T1,...,TResult> : points to a method that RETURNS TResult; the last generic type is the return type.
                 - Predicate<T> : points to a method that TAKES T and RETURNS bool (i.e., Func<T, bool>).
                 - You can assign a method group (like Print/Add/IsEven) to a compatible delegate type.
                 */



            Action<string> action = Print;
            action("Hej !");

            Func<int, int, int> addD = Add;
            Console.WriteLine(addD(2, 2));

            Predicate<int> predicate = IsEven;
            Console.WriteLine(predicate(3));

        }


        static void Print(string name) => Console.WriteLine(name);
        static int Add(int n1, int n2) => n1 + n2;
        static bool IsEven(int n) => n % 2 == 0;

    }
}
