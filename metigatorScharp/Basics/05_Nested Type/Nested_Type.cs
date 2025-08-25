using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._05_Nested_Type
{
    public class Nesteds
    {
        public class A
        {
            private int x = 1337;

            public class B
            {
                private A tmp = new A();

                public void Display()
                {
                    Console.WriteLine(tmp.x); // you can access the private type of the container 
                }
            }
        }

        public class Employee
        {
            public int Id { get; set; }

            public string Name { get; set; }

            // Add an instance of the nested Insurance class for access
            public Insurance EmployeeInsurance { get; set; }

            public class Insurance
            {
                public int PolicyId { get; set; }

                public string CompanyName { get; set; } 
            }
        }

        public static void TestNested()
        {
            // Example usage of nested classes


            //var bInstance = new A.B(); // Now accessible due to public modifier
            //bInstance.Display();



            var employee = new Employee
            {
                Id = 1,
                Name = "John Doe",
                EmployeeInsurance = new Employee.Insurance
                {
                    PolicyId = 101,
                    CompanyName = "ABC Insurance"
                }
            };

            Console.WriteLine($"Employee: {employee.Name}, Policy ID: {employee.EmployeeInsurance.PolicyId}, Company: {employee.EmployeeInsurance.CompanyName}");
        }
    }
}
