using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._07_Enums
{
    public class clsEnums
    {

        // By default, enums use int as the underlying type

        // Explicitly changing the underlying type to long ex :  enum Month : long

        enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }


        [Flags]
        enum Day
        {
            NONE        = 0b_0000_0000, // 0
            MONDAY      = 0b_0000_0001, // 1
            TUESDAY     = 0b_0000_0010, // 2
            WEDNESDAY   = 0b_0000_0100, // 4
            THURSDAY    = 0b_0000_1000, // 8
            FRIDAY      = 0b_0001_0000, // 16
            SATURDAY    = 0b_0010_0000, // 32
            SUNDAY      = 0b_0100_0000, // 64

  
            BUSDAY = MONDAY | TUESDAY | WEDNESDAY | THURSDAY | FRIDAY,
            WEEKEND = SATURDAY | SUNDAY 
        }



        public static void TestEnums()
        {

            //Console.WriteLine(Month.January);
            //Console.WriteLine((int)Month.January);


            // **********   Flag Enum   **********


            //var day = (Day.SATURDAY | Day.SUNDAY);

            //if (day.HasFlag(Day.WEEKEND))
            //    Console.WriteLine("Hej ! Enjoy ");

            //if (day.HasFlag(Day.BUSDAY))
            //    Console.WriteLine("Keep Working !!");


            // **********   Lopping on Enums   **********

            Console.WriteLine("Lopping On Enums : \n");

            foreach(var month in Enum.GetNames(typeof(Month)))
            {
                Console.WriteLine($"{month} = {(int)Enum.Parse(typeof(Month), month)}");
            }

        }


    }
}
