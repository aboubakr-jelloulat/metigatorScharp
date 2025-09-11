using System;
using System.Collections.Generic;


namespace System_Advanced._04_Working_with_NULL
{
    internal class CompileVsRunTime
    {

        public static void TCompileVsRunTime()
        {

            // compile time


            // Compile-time error: wrong type
            //int x = "hello"; // CS0029: Cannot implicitly convert type 'string' to 'int'

            // Compile-time error: unknown method
            //NotAFunction(); // CS0103: The name 'NotAFunction' does not exist in the current context






            // run time


            // Compiles fine, but fails at runtime
            int[] arr = new int[2];
            Console.WriteLine(arr[5]); // throws IndexOutOfRangeException at runtime

            string s = null;
            Console.WriteLine(s.Length); // throws NullReferenceException at runtime

            string input = "123A";
            //  "runtime" when you excuted the compiled code
            int num2 = int.Parse(input);

        }


    }
}
