using System;

namespace Basics._01_Delegate
{
    public class Report
    {


        //public void ProcessEmployeewith60000plusSales(Employee[] employees)
        //{
        //    Console.WriteLine("Employees With $60,000+ Sales : ");
        //    Console.WriteLine("\n ***************    ***************");

        //    foreach(var e in employees)
        //    {
        //        if (e.TotalSales >= 6000m)
        //        {
        //            Console.WriteLine($" {e.Id} | {e.Name}  |   {e.Gender}  |   {e.TotalSales}");
        //        }
        //    }

        //    Console.WriteLine("\n ***************    ***************");
        //}


        //public void ProcessEmployeeBetween30000And59999(Employee[] employees)
        //{
        //    Console.WriteLine("Employees Between $30,000 And $59, 999 Sales : ");
        //    Console.WriteLine("\n ***************    ***************");

        //    foreach (var e in employees)
        //    {
        //        if (e.TotalSales >= 30000 && e.TotalSales < 60000m)
        //        {
        //            Console.WriteLine($" {e.Id} | {e.Name}  |   {e.Gender}  |   {e.TotalSales}");
        //        }
        //    }

        //    Console.WriteLine("\n ***************    ***************");
        //}


        //public void ProcessEmployeeLessThan30000(Employee[] employees)
        //{
        //    Console.WriteLine("Employees Less Than $30,000  Sales : ");
        //    Console.WriteLine("\n ***************    ***************");

        //    foreach (var e in employees)
        //    {
        //        if (e.TotalSales < 30000m)
        //        {
        //            Console.WriteLine($" {e.Id} | {e.Name}  |   {e.Gender}  |   {e.TotalSales}");
        //        }
        //    }

        //    Console.WriteLine("\n ***************    ***************");
        //}




        // *********  Delegate ********



        public delegate bool IllegibleSales(Employee e);
        public void ProcessEmployee(Employee[] employees, string Title, IllegibleSales IsIllegible)
        {
            Console.WriteLine(Title);
            Console.WriteLine("\n ***************    ***************");

            foreach (var e in employees)
            {
                if (IsIllegible(e))
                {
                    Console.WriteLine($" {e.Id} | {e.Name}  |   {e.Gender}  |   {e.TotalSales}");
                }
            }

            Console.WriteLine("\n ***************    ***************");

        }

    }
}

