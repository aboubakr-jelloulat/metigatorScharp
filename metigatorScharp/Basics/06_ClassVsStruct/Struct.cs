using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._06_ClassVsStruct
{
    /*
            Differences Between struct and class in C#:

                1 - Type category : 

                    class → Reference type (stored on the heap variable holds a reference).
                    struct → Value type (stored on the stack or inline in containing types, variable holds the actual data)
                    

                2 - Default constructor : 
                    
                    class → You can define parameterless constructors.
                    struct → You cannot define an explicit parameterless constructor.


                3 - Inheritance

                    class → Can inherit from another class (single inheritance).
                    struct → Cannot inherit from another struct or class


                4 - Nullability

                    class → Variables can be null.

                    struct → By default, cannot be null (unless you use Nullable<T> or T?).


                5 - Memory allocation

                    class → Stored on the heap, garbage-collected.

                    struct → Stored on the stack (or inline), no garbage collection overhead.


                6 - Default initialization

                    class → Fields not explicitly set are initialized to null (for reference types).

                    struct → All fields are automatically initialized to their default values (e.g., 0 for numbers, false for bool).
        */

    struct Student
    {
        // public int age= 20; // Removed inline initialization to comply with C# 7.3
        public int age;
        public string Name { get; }

        public Student(string name)  // Fix: Ensure all fields are fully assigned
        {
            this.age = 20; 
            this.Name = name;   // Explicitly initialize 'Name' in the constructor
        }

        public void Display() => Console.WriteLine("Hej !");
            

    }


    public class clsStruct
    {
        public static void TestStruct()
        {
            Student st = new Student();
            Console.WriteLine(st.age); // 0 ??? Initialize by  default int with 0 ...
            st.Display();
        }


    }
}
