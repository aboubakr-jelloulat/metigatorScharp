using System;

namespace Advanced._06_Assemblies
{
    class Employee
    {

    }
    public class Assemblies
    {

        public static void TestAssemblies()
        {
            var type = typeof(Employee);
            var assembly = type.Assembly;

            Console.WriteLine(type);
            Console.WriteLine(assembly.FullName);
        }


    }
}
