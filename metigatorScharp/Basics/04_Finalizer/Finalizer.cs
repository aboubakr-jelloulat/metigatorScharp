using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._04_Finalizer
{

    /*
     *  When  Object Get Disposed ?
     * 
     *  1) - End Of Program Execution 
     *  
     *  2) - Memory Full
     *  
     *  3) - GC.Collect
     * 
     * */



    class Person
    {
        public string Name { get; set; }

        public Person() => Console.WriteLine("This is a Constractor");

        ~Person() => Console.WriteLine("This is a Destractor");

    }



    public class Finalizer
    {

        static void MakeSomeGarabge()
        {
            Version v;

            for (int i = 0; i < 1000; i++)
            {
                v = new Version();
            }
        }


        public static void SumalateGCLProcees()
        {
            MakeSomeGarabge();

            Console.WriteLine($"Memory Used Before Collection {GC.GetTotalMemory(false):N0}");
           
            GC.Collect(); // Explicit Cleaning

            Console.WriteLine($"Memory Used Before Collection {GC.GetTotalMemory(true):N0}");

        }

        public static  void TestFinalizer()
        {
            SumalateGCLProcees();


        }


    }
}
