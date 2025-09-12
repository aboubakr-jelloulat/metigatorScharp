using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;

namespace Advanced.Enumerators_Iterators
{
    class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }

        public override string ToString()
        {
            return $"Employee: {Id}, {Name}, {Department}, {Salary:C}";
        }

        // Override Equals to compare content, not just references
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Employee))
                return false;

            var other = obj as Employee;

            return this.Id == other.Id &&
                   this.Name == other.Name &&
                   this.Salary == other.Salary &&
                   this.Department == other.Department;
        }

        // you can use operation overloading 

        public static bool operator ==(Employee thi, Employee other) => thi.Equals(other);
        public static bool operator !=(Employee thi, Employee other) => !thi.Equals(other);

        // Override GetHashCode to generate a hash code based on the object's properties
        //public override int GetHashCode() //  If you’re using .NET Framework (like 4.7.2 or earlier), it does not exist, hence the error:
        //{
        //    return HashCode.Combine(Id, Name, Salary, Department);
        //}


        public override int GetHashCode()
        {
            int hash = 17;                 // start with a prime
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + (Name?.GetHashCode() ?? 0);
            hash = hash * 23 + Salary.GetHashCode();
            hash = hash * 23 + (Department?.GetHashCode() ?? 0);
            return hash;
        }


    }


    class FiveIntegers : IEnumerable
    {
        int[] _values;

        public FiveIntegers(int n1, int n2, int n3, int n4, int n5)
        {
            _values = new[] { n1, n2, n3, n4, n5 };
        }

        public IEnumerator  GetEnumerator()
        {
            foreach (var v in _values)
                yield return v; // Provides next value
        }

        // yield is a contextual keyword used in iterator methods to provide values to the
        // enumerator one at a time, while maintaining the method's state between calls.

      
    }




    // 🌡️ This class represents a Temperature object
    // IComparable interface gives it the superpower to compare itself to other Temperature objects
    // This is like teaching a robot how to line up with other robots
    class Tempreture : IComparable
    {
 
        private int _value;

        public Tempreture(int value)
        {
            _value = value;
        }

        public int Value => _value;

        // 🧠 THIS IS THE MOST IMPORTANT METHOD!
        // CompareTo is the rule that tells HOW two Temperature objects should be compared
        // This is what enables the Sort() method to do its magic
        //
        // The method returns:
        // -1 if "this" object should come BEFORE the "obj" parameter (this object is "less than")
        //  0 if both objects are equal in sorting order
        //  1 if "this" object should come AFTER the "obj" parameter (this object is "greater than")
        public int CompareTo(object obj)
        {
            // Rule 1: If we're comparing to nothing (null), this object is more important
            if (obj is null)
                return 1;

            // Rule 2: Try to treat the other object as a Temperature
            // The "as" keyword is like asking: "Are you a Temperature object?"
            var temp = obj as Tempreture;

            // Rule 2b: If it's not a Temperature object, we can't compare!
            // Throw an exception (like raising your hand and saying "I can't do this!")
            if (temp is null)
                throw new ArgumentException("object is not a tempreture object");

            // Rule 3: Finally, compare the actual values!
            // We delegate to the integer's built-in CompareTo method
            // This is like saying: "Use the same rules you'd use for comparing regular numbers"
            return this._value.CompareTo(temp._value);

            // 🎪 What's happening during Sort():
            // 1. Sort() picks two Temperature objects from the list
            // 2. It calls object1.CompareTo(object2)
            // 3. Based on the return value (-1, 0, 1), it knows their order
            // 4. It repeats this millions of times (very efficiently!) until everything is sorted
        }
    }


        public class clsEnumerators
        {
            public static void EqualLogic()
            {
                Employee e1 = new Employee { Id = 100, Name = "Sander", Department = "IT", Salary = 1500 };
                Employee e2 = new Employee { Id = 100, Name = "Sander", Department = "IT", Salary = 1500 };

                Employee e3 = e1;

                if (e1.GetHashCode() == e2.GetHashCode())
                {
                    Console.WriteLine("Objects have the same hash code");
                }
                else
                {
                    Console.WriteLine("Objects have different hash codes");
                }
            }




            
            public static void TestEnumerableYeld()
            {
                var ints = new FiveIntegers(10, 20, 30, 40, 50);

                foreach (var item in ints)
                {
                    Console.WriteLine(item);
                }

            }


            public static void TestIcomparableInterface()
            {

                var temps = new List<Tempreture>();

                Random rnd = new Random();
                for (var i = 0; i < 100; i++)
                {
                    temps.Add(new Tempreture(rnd.Next(-30, 50)));
                }



                // 🎯 MAGIC SORTING HAPPENS HERE!
                // The Sort() method is like a super-efficient sorting machine
                // But it NEEDS our CompareTo() method to know HOW to sort Temperature objects
                // Without CompareTo(), Sort() would be like a child trying to sort toys without knowing the rules
                temps.Sort();

                // Now that all temperatures are sorted (thanks to our CompareTo implementation),
                // let's display them one by one
                foreach (var item in temps)
                {
                    Console.WriteLine(item.Value);
                }


            }



            public static void TestEnumeratorsIterators()
            {

                    //EqualLogic();



                //TestEnumerableYeld();



                TestIcomparableInterface();


            }
        }
}
