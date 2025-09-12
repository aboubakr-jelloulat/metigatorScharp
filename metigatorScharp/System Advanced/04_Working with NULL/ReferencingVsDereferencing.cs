using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System_Advanced._04_Working_with_NULL
{
    //Referencing = getting the address/pointer to an object/value instead of the value itself.
    //Dereferencing = using that address to reach the actual object/value stored there.


    class Person
    {
        public string Name;
    }

    internal class ReferencingVsDereferencing
    {
        public static void TReferencingVsDereferencing()
        {
            Person p1 = new Person();
            p1.Name = "Alice";

            // Referencing: p2 now points to the same object as p1
            Person p2 = p1;

            // Dereferencing: accessing the actual object’s data
            Console.WriteLine(p2.Name); // prints "Alice"
        }


    }
}
