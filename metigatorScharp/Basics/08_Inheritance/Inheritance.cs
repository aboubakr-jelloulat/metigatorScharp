using System;

namespace Basics._08_Inheritance
{
    /*
        ===========================
           Inheritance Summary
        ===========================

        1. Abstract Class:
           - Cannot be instantiated directly.
           - Can contain normal methods and abstract methods.
           - Used as a base (blueprint) for other classes.

        2. Abstract Method:
           - Declared inside an abstract class, has no body.
           - Must be overridden in the derived (child) class.

        3. Sealed Class:
           - Cannot be inherited.
           - Used to prevent further extension of a class.

        4. Sealed Method:
           - An overridden method that cannot be overridden again.
           - Must be used inside a derived class.
           - Useful when you want to lock specific behavior.
*/



    public class Inheritance
    {
        //  Base class
        class Animal
        {
            public void Move() => Console.WriteLine("Animal is moving...");
        }

        //  Abstract class (cannot be created directly)
        abstract class Eagle : Animal
        {
            public abstract void Fly(); // must be implemented in derived classes
        }

        //  Sealed class (cannot be inherited any further)
        sealed class AmericanEagle : Eagle
        {
            public override void Fly() => Console.WriteLine("American Eagle soaring high!");
        }

        //  CanadianEagle cannot inherit AmericanEagle, because it’s sealed

        // class CanadianEagle : AmericanEagle { } // This would cause a compile error

        //  Instead, it can inherit directly from Eagle
        class CanadianEagle : Eagle
        {
            public override void Fly() => Console.WriteLine("Canadian Eagle gliding gracefully!");
        }

        public static void TestInheritance()
        {
            Console.WriteLine("=== Inheritance Test ===");

            // Upcasting (Child → Parent)
            Eagle americanEagle = new AmericanEagle();
            Eagle canadianEagle = new CanadianEagle();

            
            americanEagle.Move();
            americanEagle.Fly();

            canadianEagle.Move();
            canadianEagle.Fly();

            // ❌ Abstract Eagle cannot be created directly

            // Eagle someEagle = new Eagle(); // Compile error



        }



        // ************  [Test Poly ]  ************







        /*
        ===========================
               Object Class
        ===========================

            - The 'object' class is the base class for all types in C#.
            - Every class, struct, array, or enum implicitly inherits from object.
            - It provides useful methods that can be overridden:

               1. ToString()    -> Returns string representation of the object.
               2. Equals(obj)   -> Compares two objects for equality.
               3. GetHashCode() -> Returns hash code (used in collections).
               4. GetType()     -> Returns the runtime type of the object.

            Example:
            object obj = "Hello";   // Any type can be stored as object
            Console.WriteLine(obj.ToString()); // "Hello"
            Console.WriteLine(obj.GetType());  // System.String

        */



        class clsAnimal  // it's like you write : Object
        {
            public string Name { get; set; }

            public void  Move()
            {

                Console.WriteLine($"Animal: {Name} is Moving");
            }

            
            public override string ToString()
            {
                return base.ToString();

            }

        }






        public static void TestPoly()
        {
            Animal a = new Animal();

            Console.WriteLine(a);


        }





    }
}
