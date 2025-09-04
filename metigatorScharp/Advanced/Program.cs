using Advanced._01_Generic_delegate_Type;
using Advanced._02_Exceptions;
using Advanced._04_XML_Documentation;
using Advanced._05_Extention_Methods;
using Advanced._06_Assemblies;
using Advanced._07_Reflection___MetaData;
using Advanced.Enumerators_Iterators;
using Advanced.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ************  [ Generics ]  ************



            //clsGenerics.TestGenericsMethod();

            //clsGenerics.TestGenericsClass();

            //clsGenerics.TestGenericConstraints();




            // ************  [ Generics Delegate Type ]  ************



            //Generic_delegate.TestGeneric_delegate();

            //Generic_delegate.TestGeneric_delegateFunc_Action_Predicate();



            // ************  [ Exceptions ]  ************




            // clsExceptions.TestExceptions();





            // ************  [ Enumerators Iterators  ]  ************




            //clsEnumerators.TestEnumeratorsIterators();





            // ************  [ XML Documentation  ]  ************


            //xml.TestXml();




            // ************  [  Extention Methods  ]  ************




            //Extention.TestExtentionMethods();







            // ************  [  Assemblies  ]  ************


            // you need more practice

            // Assemblies.TestAssemblies();






            // ************  [  Reflection & MetaData  ]  ************




            Reflection_MetaData.TestReflection_MetaData();



            Console.ReadKey();
        }
    }
}
