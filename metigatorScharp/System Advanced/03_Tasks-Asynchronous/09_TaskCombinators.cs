using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{
    internal class TaskCombinators
    {
         /*
         🔹 What if we don’t use 'await'?

             - Task.WhenAny / Task.WhenAll return Task objects.
             - Without 'await', you only have the Task, not the completed result.
             - Accessing .Result will BLOCK the thread until it’s done,
               defeating the purpose of async.
             - Code may run too early (before tasks are finished), 
               leading to wrong behavior or deadlocks in UI/server apps.

             ✅ 'await' = pause async method until Task finishes (non-blocking).
             ❌ Without 'await' = you just hold a Task object, work not awaited properly.
        */



        static Task<string> Has1000Subscriber()
        {
            Task.Delay(4000).Wait();
            return Task.FromResult("congratulation !! you have 1000 subscribers");
        }

        static Task<string> Has4000ViewHours()
        {
            Task.Delay(3000).Wait();
            return Task.FromResult("congratulation !! you have 4000 view hours");
        }


        public static async Task TasksCombinators()
        {

            var has1000SubscriberTask = Task.Run(() => Has1000Subscriber());
            var has4000ViewHoursTask = Task.Run(() => Has4000ViewHours());
            Console.WriteLine("Using WhenAny()");
            Console.WriteLine("---------------");

            var any = await Task.WhenAny(has1000SubscriberTask, has4000ViewHoursTask);
            Console.WriteLine(any.Result);

            Console.WriteLine("Using WhenAll()");
            Console.WriteLine("---------------");

            var all = await Task.WhenAll(has1000SubscriberTask, has4000ViewHoursTask);
            foreach (var t in all)
            {
                Console.WriteLine(t);

            }

        }

    }
}
