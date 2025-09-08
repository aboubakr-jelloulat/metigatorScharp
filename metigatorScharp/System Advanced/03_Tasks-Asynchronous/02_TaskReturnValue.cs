using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{
    internal class TaskReturnValues
    {

        /*
         🔹 task.Result
                - Blocks the current thread until the Task finishes.
                - If the Task throws an exception:
                    * The exception is wrapped inside an AggregateException.
                    * Example: you must check ex.InnerException to see the real cause.
                - Simpler to use, but exception info is "wrapped".


         🔹 task.GetAwaiter().GetResult()
                - Also blocks the current thread until the Task finishes.
                - BUT if the Task throws an exception:
                    * The real exception is thrown directly (not wrapped).
                    * Easier to catch the original error.
                - This is closer to how `await` works internally.


         ✅ In short:
                - Both wait synchronously for the result.
                - `Result` = blocks + wraps exceptions (AggregateException).
                - `GetAwaiter().GetResult()` = blocks + throws original exception.

        */


        public static void TaskReturnValue()
        {
            Task<DateTime> task = Task.Run(GetCurrentDatetime);

            Console.WriteLine(task.Result); // block thead until result is ready

            Console.WriteLine(task.GetAwaiter().GetResult());
        }

        static DateTime GetCurrentDatetime() => DateTime.Now;

    }
}
