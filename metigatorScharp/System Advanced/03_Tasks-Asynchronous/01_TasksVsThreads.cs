using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{
    internal class TasksVsThread
    {

        /*
         🔹 THREADS vs TASKS in C#

         1) THREAD
                - A thread is like hiring a worker directly.
                - You create it with `new Thread(...)`.
                - You control when it starts, stops, or joins.
                - More power, but more work for you to manage.

         2) TASK
                - A Task is like posting a job request.
                - You just say "do this work", and .NET finds a free thread (usually from the ThreadPool).
                - Easier and higher-level than manually creating threads.
                - Supports async/await, continuations, cancellations, etc.

         🔹 THREADPOOL
                - Instead of making new threads every time (which is expensive),
                  .NET keeps a pool of worker threads ready.
                - Tasks usually use these pooled threads automatically.
                - Example: `Task.Run(() => { ... });` will use a thread from the pool.

         🔹 FOREGROUND vs BACKGROUND THREADS
                - Foreground thread:
                    * Keeps the program alive until it finishes.
                    * Example: Main application logic, critical work.
                - Background thread:
                    * Program can exit even if this thread is still running.
                    * Example: Logging, monitoring, timers, cleanup helpers.
                - Use background threads for "extra work" that shouldn’t block exit.

         🔹 FORK / JOIN pattern (optional concept)
                - Fork: split work into multiple threads or tasks.
                - Join: wait for all to finish before continuing.
        */



        /*
            Why use Task over Thread?

            ─────────────────────────────────────────────
            CRITERIA                 THREAD          TASK
            ─────────────────────────────────────────────
            Concept                  Low Level       Abstraction
               

            Leveraging Thread Pool   No              Yes
                

            Return Value             No              Yes
                

            Chaining                 No              Yes
                

            Exception Propagation    No              Yes
               

            Task Type                Foreground/     Background only
                                     Background
                

            Support Cancellation     No              Yes
                

            ─────────────────────────────────────────────
            SUMMARY:
            - Threads are low-level and require manual management.
            - Tasks provide abstraction, return values, chaining, exception handling,
              thread pooling, cancellation, and overall better performance.
        */





        static void ShowThreadDetails(Thread th)
        {
            Console.WriteLine($"Th id : {th.ManagedThreadId}, Pooled {th.IsThreadPoolThread}, Backround : {th.IsBackground}");

        }

        static void DisplayInfo(string message)
        {
            ShowThreadDetails(Thread.CurrentThread);

            Console.WriteLine(message);

        }


        public static void TaskVsThreads()
        {
            var th = new Thread(() => DisplayInfo("Hej ! Im thread"));

            th.Start();
            th.Join();

            // **** Task 

            Task.Run(() => DisplayInfo("Hej ! Im Task ")).Wait();


        }

    }
}
