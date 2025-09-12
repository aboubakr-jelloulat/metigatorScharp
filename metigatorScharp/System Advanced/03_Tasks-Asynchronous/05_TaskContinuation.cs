using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{
    internal class TaskContinuations
    {
        /*
         🔹 Getting results from a Task

             -- 1) task.Result
                • Blocks the current thread until the Task finishes.
                • Bad for responsiveness (UI freeze, thread stuck).
                • "Mitigator" is printed only AFTER the calculation is done.

         -- 2) task.GetAwaiter().OnCompleted(...)
                • Non-blocking: you give a callback to run when the Task is done.
                • "Mitigator" prints first (immediately).
                • When the Task completes, OnCompleted runs, and we safely call GetResult().
                • This pattern is how async/await works internally.

         -- 3) task.ContinueWith(...)
                • Also non-blocking: schedules a continuation after the Task finishes.
                • "Mitigator" prints first (immediately).
                • Then the continuation executes with the Task’s result.
                • More verbose than awaiter, but useful for chaining multiple tasks.

         ✅ Summary:
                - Result → blocks until finished ❌ (not ideal).
                - OnCompleted → callback after finish ✅ (non-blocking).
                - ContinueWith → continuation after finish ✅ (non-blocking, chainable).
        */




        public static void TaskContinuation()
        {
            //Console.WriteLine(CountPrimeNumberInARange(2, 2_000_000));

            Task<int> task = Task.Run(() => CountPrimeNumberInARange(2, 3_000_000));

            // -- 1 
            //Console.WriteLine(task.Result); // bad it blocks the thead
            //Console.WriteLine("Metigator"); // after calcul 


            // 2- same 3 
            //Console.WriteLine("using awaiter, onComplete");
            //var awaiter = task.GetAwaiter(); // Metigator the first
            //awaiter.OnCompleted(() =>
            //{
            //    Console.WriteLine(awaiter.GetResult()); // block the thread but task is completed
            //});

            //Console.WriteLine("Metigator");



            Console.WriteLine("using task continuewith");

            task.ContinueWith((x) => Console.WriteLine(x.Result));
            Console.WriteLine("Metigator");


        }



        static int CountPrimeNumberInARange(int lowerBound, int upperBound)
        {
            var count = 0;
            for (int i = lowerBound; i < upperBound; i++)
            {
                var j = 2;
                var isPrime = true;
                while (j <= (int)Math.Sqrt(i))
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    ++j;
                }

                if (isPrime)
                    ++count;
            }
            return count;
        }

    }
}
