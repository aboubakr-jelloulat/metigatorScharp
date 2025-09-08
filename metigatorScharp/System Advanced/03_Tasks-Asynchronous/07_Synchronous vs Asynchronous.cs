using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{

    /*
     🔹 Synchronous vs Asynchronous in C#

     1) Synchronous (blocking)
        - Tasks run one after another.
        - The current thread waits for each task to finish.
        - Example: Thread.Sleep(2000); // blocks the thread
        - Use when you must wait before moving to the next step.

     2) Asynchronous (non-blocking)
        - Tasks can run without blocking the current thread.
        - Use 'async/await' or Task continuations.
        - Example: await Task.Delay(2000); // does not block the thread
        - Allows the program to stay responsive (UI, server requests, etc.)

     ✅ Summary:
        - Sync = wait, block, strict order
        - Async = don’t block, can do other work while waiting
    */

    internal class SynchronousVsAsynchronous
    {
        static void SynchronousExample()
        {
            Console.WriteLine("Start Task 1");
            Thread.Sleep(2000); // Wait 2 seconds
            Console.WriteLine("End Task 1");

            Console.WriteLine("Start Task 2");
            Thread.Sleep(1000); // Wait 1 second
            Console.WriteLine("End Task 2");
        }

         static async Task AsynchronousExample()
        {
            Console.WriteLine("Start Task 1");
            await Task.Delay(2000); // Wait 2 seconds asynchronously
            Console.WriteLine("End Task 1");

            Console.WriteLine("Start Task 2");
            await Task.Delay(1000); // Wait 1 second asynchronously
            Console.WriteLine("End Task 2");
        }


        public static async Task TestSynchronousVsAsynchronousAsync()
        {

            //Console.WriteLine("=== Synchronous Example ===");
            //SynchronousExample();

            //Console.WriteLine("\n=== Asynchronous Example ===");
            //// For async method, we need to wait for it in Main

            //AsynchronousExample().GetAwaiter().GetResult();


            // Async function 

            Console.WriteLine(await ReadContentAsync("https://www.youtube.com/c/Metigator"));
            Console.ReadKey();


        }

        static Task<string> ReadContent(string url)
        {
            var client = new HttpClient();

            var task = client.GetStringAsync(url);

            return task;
        }

        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();

            var content = await client.GetStringAsync(url);

            return content;
        }

    }
}
