using System;
using System_Advanced._00_Stream;
using System_Advanced._01_Nuget_Packages;
using System_Advanced._03_Tasks_Asynchronous;
using System_Advanced._04_Yield;
using System_Advanced._04_Yield_Foreach;
using System_Advanced.Threading;

namespace System_Advanced
{
    public  class Program
    {
        static void Main(string[] args)
        {
            NewMethod();

            Console.ReadKey();

        }

        private static void NewMethod()
        {

            // *********** [ Stream I/O ]  ***********




            //stream.TestStream();




            // *********** [ Nuget Packages And Packaging ]  ***********

            // ==>  bash tban leek dik 12 days ago .. + install upload 100 % Amazing lesson

            //Nuget.Test();





            // *********** [Threading ]  ***********


            //clsThreading.MasterThreading();




            // *********** [Tasks Multithreading ]  ***********



            //TasksVsThread.TaskVsThreads();

            //TaskReturnValues.TaskReturnValue();

            //LongRunningTask.LongRunningTasks();

            //ExceptionPropagation.ExceptionPropagations();

            //TaskContinuations.TaskContinuation();

            //TaskDelay.ft_TaskDelay();

            //SynchronousVsAsynchronous.TestSynchronousVsAsynchronousAsync();

            //CancellationToken.CancellationTokensAsync();

            //TaskCombinators.TasksCombinators();

            //ConcurrencyAndParallelism.ConcurrencyAnd_Parallelism();



            // *********** [ Yield ]  ***********

            //Foreach.TestForeach();

            Yield.TestYield();



            Console.ReadKey();
        }
    }
}
