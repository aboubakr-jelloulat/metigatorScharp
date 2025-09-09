using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System_Advanced._03_Tasks_Asynchronous
{
    internal class CancellationToken
    {


        public static async Task CancellationTokensAsync()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //await DoCheck01(cancellationTokenSource);
            //await DoCheck02(cancellationTokenSource);
            await DoCheck03(cancellationTokenSource);

        }

        static async Task DoCheck01(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() => {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine("Task has been cancelled !!!");
                }
            });

            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                Console.Write("Checking ...");
                await Task.Delay(4000);
                Console.Write($" Completed on {DateTime.Now}");
                Console.WriteLine();
            }

            Console.WriteLine("Check was Terminated");
            cancellationTokenSource.Dispose();
        }

        static async Task DoCheck02(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() => {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine("Task has been cancelled !!!");
                }
            });

            while (true)
            {
                Console.Write("Checking ...");
                await Task.Delay(4000, cancellationTokenSource.Token);
                Console.Write($" Completed on {DateTime.Now}");
                Console.WriteLine();
            }

            Console.WriteLine("Check was Terminated");
            cancellationTokenSource.Dispose();
        }

        static async Task DoCheck03(CancellationTokenSource cancellationTokenSource)
        {
            Task.Run(() => {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();
                    Console.WriteLine("Task has been cancelled !!!");
                }
            });

            try
            {
                while (true)
                {
                    cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    Console.Write("Checking ...");
                    await Task.Delay(4000);
                    Console.Write($" Completed on {DateTime.Now}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Check was Terminated");
            cancellationTokenSource.Dispose();
        }
    }
}
