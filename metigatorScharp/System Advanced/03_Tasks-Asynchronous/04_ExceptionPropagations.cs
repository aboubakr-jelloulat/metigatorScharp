using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{
            /*
            🔹 Exception Handling in Threads vs Tasks

         -- 1) Raw Thread + try/catch in MAIN thread
             try
             {
                 var th = new Thread(ThrowException);
                 th.Start();
                 th.Join();
             }
             catch { ... }

             • The exception is thrown inside the new worker thread.
             • But the try/catch is in the MAIN thread.
             • In .NET, exceptions do NOT cross thread boundaries.
             • Result: the catch block in MAIN is never triggered.
               (program crashes if not handled inside the worker).

         -- 2) Raw Thread + try/catch INSIDE the worker thread
             var th = new Thread(ThrowExceptionWithTryCatchBlock);
             th.Start();
             th.Join();

             • The exception is thrown and caught inside the worker thread itself.
             • This works: we see "Exception is thrown!!".
             • If we re-throw (`throw;`), the exception ends with that thread
               and never comes back to MAIN.
             • Rule: with raw Thread, you must handle errors inside the same thread.

         -- 3) Task + try/catch in MAIN thread
             try
             {
                 Task.Run(ThrowException).Wait();
             }
             catch { ... }

             • A Task captures exceptions internally.
             • When you call `.Wait()` (or `.Result` / `await`), the stored exception
               is re-thrown on the calling thread (here: MAIN).
             • Result: the catch block in MAIN *does* run.
             • This makes Tasks much safer and easier for error handling.

         ✅ Summary:
            - Thread + catch outside → ❌ exception lost (not caught in MAIN).
            - Thread + catch inside  → ✅ works, but must be handled in worker.
            - Task + catch outside   → ✅ works, exception is propagated back.
        */


    internal class ExceptionPropagation
    {
        public static void ExceptionPropagations()
        {
            // -- 1 -- Raw Thread with try/catch outside


            //try
            //{
            //    var th = new Thread(ThrowException);
            //    th.Start();
            //    th.Join();
            //}
            //catch
            //{
            //    Console.WriteLine("Exception is thrown!!");
            //}



            // -- 2 --  Raw Thread with try/catch inside the worker

            //var th = new Thread(ThrowExceptionWithTryCatchBlock);
            //th.Start();
            //th.Join();


            // -- 3 -- Task with try/catch outside

            //try
            //{
            //    Task.Run(ThrowException).Wait();
            //}
            //catch
            //{
            //    Console.WriteLine("Exception is thrown!!");

            //}



        }

        static void ThrowException()
        {
            throw new NullReferenceException();
        }

        static void ThrowExceptionWithTryCatchBlock()
        {
            try
            {
                throw new NullReferenceException();

            }
            catch
            {
                Console.WriteLine("Exception is thrown!!");

                throw;
            }
        }


    }
}
