using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{
    internal class ConcurrencyAndParallelism
    {
        class DailyDuty
        {
            public string title { get; private set; }

            public bool Processed { get; private set; }

            public DailyDuty(string title)
            {
                this.title = title;
            }

            public void Process()
            {
                Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}," +
                    $"ProcessorId: ");
                Task.Delay(100).Wait();
                this.Processed = true;
            }
        }

        public static async Task ConcurrencyAnd_Parallelism()
        {
            var things = new List<DailyDuty>
            {
                new DailyDuty("Cleaning House"),
                new DailyDuty("Washing Dishes"),
                new DailyDuty("Doing Laundry"),
                new DailyDuty("Preparing Meals"),
                new DailyDuty("Checking Emails"),
                new DailyDuty("Cleaning House")
            };

            //Console.WriteLine("Using Parallel Processing");
            //await ProcessThingsInParallel(things);

            Console.WriteLine("Using Concurrent Processing");
            await ProcessThingsInConcurrent(things);


        }


        static Task ProcessThingsInParallel(IEnumerable<DailyDuty> things)
        {
            Parallel.ForEach(things, thing => thing.Process());
            return Task.CompletedTask;
        }

        static Task ProcessThingsInConcurrent(IEnumerable<DailyDuty> things)
        {
            foreach (var thing in things)
            {
                thing.Process();
            }
            return Task.CompletedTask;
        }


    }
}
