using Advanced._01_Generic_delegate_Type;
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


            Generic_delegate.TestGeneric_delegate();

            //Generic_delegate.TestGeneric_delegateFunc_Action_Predicate();



            Console.ReadKey();
        }
    }
}
