using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basics._00_Indexers;
using Basics._01_Delegate;
using Basics._02_Events;
using Basics._03_Operator_Overloading;
using Basics._04_Finalizer;
using Basics._05_Nested_Type;
using Basics.Debugging;
using Basics._06_ClassVsStruct;
using Basics._07_Enums;


namespace Basics
{
    public class Program
    {

        static void Main(string[] args)
        {

            // ************  [Indexers]  ************


            //Indexers.TestIndexers();


            // ************  [Delegate]  ***********


            //clsDelegate.TestDelegate();



            // ************  [Events]  ************



            //clsEvents.TestEvents();



            // ************  [ Operator Overloading ]  ************



            // OPOverloading.TestOPOverloading();



            // ************  [ Finalizer ]  ************


            // Finalizer.TestFinalizer();




            // ************  [ Nested Types ]  ************


            //Nesteds.TestNested();



            // ************  [ Debugging ]  ************


            // clsDebugging.TestDebugging();



            // ************  [ Class Vs  Struct ]  ************



            // clsStruct.TestStruct();




            // ************  [ Enums ]  ************



            clsEnums.TestEnums();





            Console.ReadKey();
        }
    }
}
