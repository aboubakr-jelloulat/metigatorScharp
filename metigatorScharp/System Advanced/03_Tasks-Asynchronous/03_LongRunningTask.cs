using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{
    internal class LongRunningTask
    {

        // *** The Main Diffrence : Is Not use Pooled Thread
        static void RunLongTask()
        {
            Thread.Sleep(3000);
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine("Completed");
        }
        static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }


        public static void LongRunningTasks()
        {
            var task = Task.Factory.StartNew(() => RunLongTask(), TaskCreationOptions.LongRunning);


        }

    }
}
