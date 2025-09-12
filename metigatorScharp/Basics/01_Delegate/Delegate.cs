using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._01_Delegate
{

    public class RectangleHelper
    {
        public void GetArea(decimal width, decimal height)
        {
            var result = width * height;
            Console.WriteLine($"Area: {width} x {height} = {result}");
        }

        public void GetPerimeter(decimal width, decimal height)
        {
            var result = 2 * (width + height);
            Console.WriteLine($"Perimeter: 2 x ({width} + {height}) = {result}");
        }
    }

    public class clsDelegate
    {

        public static void TestDelegate()
        {
            var emps = new Employee[]
            {
                new Employee { Id = 1, Name = "Issam A", Gender = "M", TotalSales = 65000m },
                new Employee { Id = 2, Name = "Reem S", Gender = "F", TotalSales = 50000m },
                new Employee { Id = 3, Name = "Suzan B", Gender = "F", TotalSales = 65000m },
                new Employee { Id = 4, Name = "Sara A", Gender = "F", TotalSales = 40000m },
                new Employee { Id = 5, Name = "Salah C", Gender = "M", TotalSales = 42000m },
                new Employee { Id = 6, Name = "Rateb A", Gender = "M", TotalSales = 30000m },
                new Employee { Id = 7, Name = "Abeer C", Gender = "F", TotalSales = 16000m },
                new Employee { Id = 8, Name = "Marwan M", Gender = "M", TotalSales = 15000m },
            };


            var report = new Report();

            // *********  bad practice ********

            //report.ProcessEmployeewith60000plusSales(emps);

            //report.ProcessEmployeeBetween30000And59999(emps);

            //report.ProcessEmployeeLessThan30000(emps);


            // *********  bad practice ********


            // **** - way 1 :  Function pointer ****


            //report.ProcessEmployee(emps, "Employees With $60,000+ Sales", IsGraterThanOrEqual60000);

            //report.ProcessEmployee(emps, "Employees Between $30,000 And $59, 999 Sales", IsBetween30000And60000);

            //report.ProcessEmployee(emps, "Employees Between $30,000 And $59, 999 Sales", IsLessThan30000);




            // ****  way 2 :  Anonymous Delegates  ****

            //report.ProcessEmployee(emps, "Employees With $60,000+ Sales", delegate (Employee e) { return e.TotalSales >= 60000; });

            //report.ProcessEmployee(emps, "Employees Between $30,000 And $59, 999 Sales", delegate (Employee e) { return e.TotalSales >= 30000m && e.TotalSales <= 60000; });

            //report.ProcessEmployee(emps, "Employees Between $30,000 And $59, 999 Sales", delegate (Employee e) { return e.TotalSales < 30000m; });




            // ****  way 3 :  Lambda Expression  ****



            //report.ProcessEmployee(emps, "Employees With $60,000+ Sales",  (e) => e.TotalSales >= 60000);

            //report.ProcessEmployee(emps, "Employees Between $30,000 And $59, 999 Sales",  (e) =>  e.TotalSales >= 30000m && e.TotalSales <= 60000 );

            //report.ProcessEmployee(emps, "Employees Between $30,000 And $59, 999 Sales", (e) =>  e.TotalSales < 30000m);





            // ********     Multicasting    ********


            var helper = new RectangleHelper();

            RectDelegate delg;

            delg = helper.GetArea;

            delg += helper.GetPerimeter;

            delg(10, 10);

            delg -= helper.GetPerimeter;


            Console.WriteLine("\nAfter unsubscribing GetPerimeter\n");

            delg(10, 10);

        }

        public delegate void RectDelegate(decimal with, decimal height);

        static bool IsGraterThanOrEqual60000(Employee e) => e.TotalSales >= 60000;

        static bool IsBetween30000And60000(Employee e) => e.TotalSales >= 30000m && e.TotalSales <= 60000;

        static bool IsLessThan30000(Employee e) => e.TotalSales < 30000m;

    }
}
