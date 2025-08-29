using System;


namespace Advanced.Generics
{
    public class clsGenerics
    {
        static void  Print<T>(T value)
        {
            Console.WriteLine($"Data Type : {typeof(T)}");
            Console.WriteLine($"Value : {value}\n");
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }


        public static void TestGenericsMethod()
        {
            Console.WriteLine("[ Generic Method : ] \n\n");


            //Print(42);
            //Print("Hej");


            int x = 42, y = 1337;
            Console.WriteLine($"Before: x = {x}, y = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"After: x = {x}, y = {y}");

            string str1 = "Hello", str2 = "World";
            Console.WriteLine($"\nBefore: str1 = {str1}, str2 = {str2}");
            Swap(ref str1, ref str2);
            Console.WriteLine($"After: str1 = {str1}, str2 = {str2}");


        }











        public class MyList<T>
        {
            private T[] _items;

            public void Add(T item)
            {
                if (_items == null)
                {
                    _items = new T[] { item };
                }
                else
                {
                    var length = _items.Length;
                    var dest = new T[length + 1];

                    for (int i = 0; i < length; i++)
                    {
                        dest[i] = _items[i];
                    }

                    dest[dest.Length - 1] = item;
                    _items = dest;
                }
            }

            public void RemoveAt(int position)
            {
                if (_items == null || position < 0 || position >= _items.Length)
                    return;

                var dest = new T[_items.Length - 1];
                int index = 0;

                for (int i = 0; i < _items.Length; i++)
                {
                    if (i == position) 
                        continue;

                    dest[index] = _items[i];
                    index++;
                }

                _items = dest;
            }

            public void Print()
            {
                if (_items == null)
                {
                    Console.WriteLine("[]");
                    return;
                }

                Console.Write("[ ");
                foreach (var item in _items)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine("]");
            }
        }



       




        public static void TestGenericsClass()
        {
            //Console.WriteLine("[ Generic class with Int  : ] \n\n");


            //var list = new MyList<int>();

            //list.Add(10);
            //list.Add(20);
            //list.Add(30);
            //list.Add(40);

            //Console.WriteLine("Before Remove:");
            //list.Print();

            //list.RemoveAt(2);

            //Console.WriteLine("After Remove:");
            //list.Print();




            //Console.WriteLine("[ Generic class with Strings  : ] \n\n");



            //var lst = new MyList<string>();

            //lst.Add("Apple");
            //lst.Add("Banana");
            //lst.Add("Orange");
            //lst.Add("Mango");

            //Console.WriteLine("Before Remove:");
            //lst.Print();   // [ Apple Banana Orange Mango ]

            //lst.RemoveAt(1);  // remove "Banana"

            //Console.WriteLine("After Remove:");
            //lst.Print();   // [ Apple Orange Mango ]



        }


        // ********  [ Generic Constraints  : ]  ********


        /*
            GENERIC CONSTRAINTS IN C#

            Generic constraints are rules applied to type parameters in generic classes or methods,
            specifying what kinds of types can be used for the type parameter.

            TYPES OF GENERIC CONSTRAINTS:

            1. where T : struct
               - T must be a value type (e.g., int, double, DateTime)
       
            2. where T : class
               - T must be a reference type (e.g., string, custom classes)
       
            3. where T : new()
               - T must have a public parameterless constructor, allowing "new T()" inside the generic class/method
       
            4. where T : BaseClass
               - T must inherit from the specified base class
       
            5. where T : InterfaceName
               - T must implement the specified interface
       
            6. Multiple constraints
               - You can combine constraints, e.g.:
                 where T : class, IComparable<T>, new()
         
            NOTES:
            - You cannot constrain T to a specific type like int or string directly.
            - Constraints provide type safety, better performance, and clear rules for generic usage.
        */






        public class Factory<T> where T : new()
        {
            public T Create()
            {
                return new T(); // Works only if T has a public parameterless constructor
            }
        }

        public class Product
        {
            public Product() { }  //  Has parameterless constructor
        }


        public static void TestGenericConstraints()
        {

            Factory<Product> factory = new Factory<Product>();
            Product p = factory.Create();



            // you can't use int or ....

        }






    }
}
