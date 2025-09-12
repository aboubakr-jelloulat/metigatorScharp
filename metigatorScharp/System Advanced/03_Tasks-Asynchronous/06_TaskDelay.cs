using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{
    /*
     🔹 Understanding Task.Delay + GetAwaiter

     1) Task.Delay(ms)
            - Creates a Task that completes after 'ms' milliseconds.
            - Does NOT block the current thread.

     2) GetAwaiter()
            - Returns an awaiter object for the Task.
            - The awaiter has two main methods:
                • OnCompleted(callback) → runs callback when Task finishes (non-blocking)
                • GetResult()           → blocks until Task finishes and returns result

     3) OnCompleted(callback)
            - Registers a callback to run AFTER the Task completes.
            - Method returns immediately; the thread is NOT blocked.
            - Example: Task.Delay(5000).GetAwaiter().OnCompleted(() => Console.WriteLine("Done"));

     4) GetResult()
            - Waits synchronously until the Task finishes.
            - Equivalent to Task.Delay(ms).Wait()
            - Example: Task.Delay(5000).GetAwaiter().GetResult(); Console.WriteLine("Done");

     ✅ Summary:
            - OnCompleted → non-blocking, async callback
            - GetResult   → blocking, waits for Task to finish
            - Task.Delay alone → does NOT wait, code continues immediately
         */



    internal class TaskDelay
    {
        public static void ft_TaskDelay()
        {
            DelayUsingTask(5000);

        }


        static void DelayUsingTask(int ms)
        {
            //Task.Delay(ms);

            //Console.WriteLine($"Completed after Thread.Sleep({ms})");

            // 2 -

            Task.Delay(ms).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine($"Completed after Task.Delay({ms})");

            });
        }

        static void SleepUsingThread(int ms)
        {
            Thread.Sleep(ms);
            Console.WriteLine($"Completed after Thread.Sleep({ms})");

        }

    }
}
