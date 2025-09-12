using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices; 
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System_Advanced.Threading
{

    class Wallet
    {
        public Wallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }


        public void Debit(int amount)
        {
            Thread.Sleep(1000);
            Bitcoins -= amount;
            Console.WriteLine(
                $"[Thread: {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name} " +
                $", Processor Id: Not fount in .NET Framwork ] -{amount}");
        }

        public void Credit(int amount)
        {
            Thread.Sleep(1000);
            Bitcoins += amount;
            Console.WriteLine(
                $"[Thread: {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name} " +
                $", Processor Id: Not fount in .NET Framwork] +{amount}");
        }

        public void RunRandomTransactions()
        {
            int[] amounts = { 10, 20, 30, -20, 10, -10, 30, -10, 40, -20 }; // 80

            foreach (var amount in amounts)
            {
                var absValue = Math.Abs(amount);
                if (amount < 0)
                    Debit(absValue);
                else
                    Credit(absValue);

            }
        }

        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }



    }


    class RaceWallet
    {
        private readonly object bitcoinsLock = new object();
        public RaceWallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }


        public void Debit(int amount)
        {
            lock (bitcoinsLock) // Avoid Race Condition 
            {
                if (Bitcoins >= amount)
                {
                    Thread.Sleep(1000);

                    Bitcoins -= amount;
                }
            }
        }

        public void Credit(int amount)
        {
            Thread.Sleep(1000);
            Bitcoins += amount;
        }


        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }
    }


    class DeadWallet
    {
        private readonly object bitcoinsLock = new object();
        public DeadWallet(int id, string name, int bitcoins)
        {
            Id = id;
            Name = name;
            Bitcoins = bitcoins;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Bitcoins { get; private set; }


        public void Debit(int amount)
        {
            lock (bitcoinsLock)
            {
                if (Bitcoins >= amount)
                {
                    Thread.Sleep(1000);

                    Bitcoins -= amount;
                }
            }
        }

        public void Credit(int amount)
        {
            Thread.Sleep(1000);
            Bitcoins += amount;
        }


        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }
    }

    class TransferManager
    {
        private DeadWallet from;
        private DeadWallet to;

        private int amountToTransfer;

        public TransferManager(DeadWallet from, DeadWallet to, int amountToTransfer)
        {
            this.from = from;
            this.to = to;
            this.amountToTransfer = amountToTransfer;
        }

        public void Transfer()
        {
            var lock1 = from.Id < to.Id ? from : to;
            var lock2 = from.Id < to.Id ? to : from;

            Console.WriteLine($"{Thread.CurrentThread.Name} trying to lock ... {from}");
            lock (lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} lock acquired ... {from}");
                Thread.Sleep(1000);
                Console.WriteLine($"{Thread.CurrentThread.Name} trying to lock ... {to}");

                lock (lock2)
                {
                    from.Debit(amountToTransfer);
                    to.Credit(amountToTransfer);
                }
            }
        }
    }


    public class clsThreading
    {

        static void ProcessAndThread()
        {
            Console.WriteLine($"Process Id: {Process.GetCurrentProcess().Id}");
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
           

        }


        static void CAMultiThreading()
        {
            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine(Thread.CurrentThread.Name);


            Console.WriteLine($"Backround Thread : {Thread.CurrentThread.IsBackground}");
            var wallet = new Wallet("Baker", 100);

            Thread th1 = new Thread(wallet.RunRandomTransactions);
            th1.Name = " Th1";
             
            Console.WriteLine($"Backround Thread : {th1.IsBackground}");
            Console.WriteLine($"After declaration {th1.Name} state is :  {th1.ThreadState}");

            th1.Start();

            th1.Join(); // allow one thread to wait for the completion of another

            Console.WriteLine($"After Start {th1.Name} state is :  {th1.ThreadState}");
       

            Thread t2 = new Thread(new ThreadStart(wallet.RunRandomTransactions));
            t2.Name = " Th2";
            t2.Start();

            //Console.WriteLine($"after start {t1.Name} state is: {t1.ThreadState}");

        }


        static void RaceCondition()
        {
            var raceWallet = new RaceWallet("Issam", 50);

            //raceWallet.Debit(40);
            //raceWallet.Debit(30); // 10

            //Console.WriteLine(raceWallet);


            var t1 = new Thread(() => raceWallet.Debit(40));
            var t2 = new Thread(() => raceWallet.Debit(30));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();


            Console.WriteLine(raceWallet);

        }


        static void DeadLock()
        {

        /*
            DEADLOCK EXPLAINED:

                A deadlock occurs when two or more threads are blocked forever,
                each waiting for a resource held by the other. Think of it like
                two friends each holding a toy the other wants—they won't let
                go, and both are stuck waiting forever.

            CONDITIONS FOR DEADLOCK:
                1. Mutual Exclusion: Only one thread can hold a resource at a time.
                2. Hold and Wait: Threads hold resources while waiting for others.
                3. No Preemption: Resources cannot be forcibly taken from a thread.
                4. Circular Wait: Threads form a circular chain, each waiting for the next.

            EXAMPLE SCENARIO IN C#:
                Thread 1 locks resource A then tries to lock resource B.
                Thread 2 locks resource B then tries to lock resource A.
                Both threads are now waiting for each other indefinitely → DEADLOCK.

            HOW TO PREVENT DEADLOCK:
                1. Always acquire locks in the same order across all threads.
                2. Use Monitor.TryEnter with a timeout to avoid waiting forever.
                3. Minimize nested locks and the time each lock is held.
                4. Use higher-level thread-safe collections (ConcurrentQueue, ConcurrentDictionary)
                   or async primitives (SemaphoreSlim, async/await) when possible.
                5. Detect potential deadlocks during debugging using thread states or logging.

            KEY POINT:
                Deadlocks are subtle and often hard to spot during runtime.
                Careful lock design and avoiding complex nested locks are the best ways to prevent them.
        */




            var wallet1 = new DeadWallet(1, "Issam", 100);
            var wallet2 = new DeadWallet(2, "Reem", 50);
            Console.WriteLine("\n Before Transaction");
            Console.WriteLine("\n---------------------");
            Console.Write(wallet1 + ", "); Console.Write(wallet2); Console.WriteLine();
            Console.WriteLine("\n After Transaction");
            Console.WriteLine("\n---------------------");

            var transferManager1 = new TransferManager(wallet1, wallet2, 50);
            var transferManager2 = new TransferManager(wallet2, wallet1, 30);

            var t1 = new Thread(transferManager1.Transfer);
            t1.Name = "T1";

            var t2 = new Thread(transferManager2.Transfer);
            t2.Name = "T2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.Write(wallet1 + ", "); Console.Write(wallet2); Console.WriteLine();

        }


        static void LearnThreadPool()
        {

            /*
            THREAD POOL EXPLAINED:

                - A Thread Pool is a collection of pre-created background threads
                  ready to execute tasks.  
                - Instead of creating a new thread every time (which is expensive),
                  tasks are assigned to available threads in the pool.  
                - Threads are reused after completing work, improving performance
                  and reducing resource overhead.  
                - Ideal for short-lived tasks or lots of concurrent operations.  
                - Avoid using for long-running blocking tasks, as it may exhaust
                  the pool.
            */



            Console.WriteLine("Using ThreadPool");

            //1 
            ThreadPool.QueueUserWorkItem(new WaitCallback(Print));


            Console.WriteLine("Using Task");
            //2 
            Task.Run(Print);


            var employee = new Employee { Rate = 10, TotalHours = 40 };

            ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateSalary), employee);

            Console.WriteLine(employee.TotalSalary);

        }

        public static void MasterThreading()
        {

            /*
             * 
            FOREGROUND vs BACKGROUND THREADS:

                    - Foreground threads keep the app alive until they finish.
                    - Background threads run in the background and are killed 
                      automatically when all foreground threads end.
                    - Use foreground for critical tasks, background for helpers or monitoring.
        */



            // ProcessAndThread();

            //CAMultiThreading();


            //RaceCondition();


            //DeadLock();


            LearnThreadPool();

        }


        private static void CalculateSalary(object employee)
        {
            var emp = employee as Employee;
            if (employee is null)
                return;
            emp.TotalSalary = emp.TotalHours * emp.Rate;
            Console.WriteLine(emp.TotalSalary.ToString("C"));
        }

        private static void Print()
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Thread Name: {Thread.CurrentThread.Name}");
            Console.WriteLine($"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"Background: {Thread.CurrentThread.IsBackground}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Cycle {i + 1}");
            }
        }

        private static void Print(object state)
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Thread Name: {Thread.CurrentThread.Name}");
            Console.WriteLine($"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"Background: {Thread.CurrentThread.IsBackground}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Cycle {i + 1}");
            }
        }


    }


    class Employee
    {
        public decimal TotalHours { get; set; }
        public decimal Rate { get; set; }

        public decimal TotalSalary { get; set; }

    }

}
