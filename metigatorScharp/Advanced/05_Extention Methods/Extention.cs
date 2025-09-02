using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced._05_Extention_Methods
{
    public  class Extention
    {

        public static void DateTimeMethods()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine($"Date Time Now : {dt}\n");


            dt = new DateTime(2025, 08, 24, 14, 30, 00);
            Console.WriteLine($"Date Time : {dt}\n");

            dt = dt.AddDays(4);
            Console.WriteLine($"Date Time after add 4 days : {dt}\n");



        }

        public static void Date_TimeOffset()
        {
            DateTimeOffset dts = DateTimeOffset.Now;
            Console.WriteLine($"Date Time Offset Now is : {dts}");

            dts = DateTimeOffset.UtcNow;
            Console.WriteLine($"Date Time Offset UTC is : {dts}");

        }


        // An extension method is a static method that allows you to "add" new methods to an existing type without modifying its original class.

        // 1 _ It must be inside a static class

        // 2 - The method must be static, and the first parameter must use this
        public static void ExtentionsMethode()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine($"Date Time Now : {dt}\n");

            dt =  dt.AddDays(4);

            Console.WriteLine($"Is weekEnd : {dt.IsWeekEnd()}");
            Console.WriteLine($"Is weekDay : {dt.IsWeekDay()}");

        }


        public static void TestExtentionMethods()
        {

            //DateTimeMethods();


            //Date_TimeOffset();

            ExtentionsMethode();

        }

    }
}
