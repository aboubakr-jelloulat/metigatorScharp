using System;


namespace Basics._09_Interface
{
    public class clsInterface
    {

        interface ILoader
        {
            void Load();
            void Unload();
        }


        interface IDrivable
        {
            void Move();
            void Stop();

        }


        abstract class Vehicle // abstract type
        {
            protected string Brand;
            protected string Model;
            protected int Year;

            public Vehicle(string brand, string model, int year)
            {
                Brand = brand;
                Model = model;
                Year = year;
            }
        }


        class Honda : Vehicle , IDrivable
        {
            public Honda(string brand, string model, int year) : base(brand, model, year)
            {

            }

            public void Move()
            {
                Console.WriteLine("Moving ...");
            }

            public void Stop()
            {
                Console.WriteLine("Stopping ...");
            }
        }

        class Caterpillar : Vehicle, ILoader, IDrivable
        {
            public Caterpillar(string brand, string model, int year) : base(brand, model, year)
            {

            }

            public void Load()
            {
                Console.WriteLine("Loading ...");
            }

            public void Unload()
            {
                Console.WriteLine("UnLoading ...");
            }

            public void Move()
            {
                Console.WriteLine("Moving ...");
            }

            public void Stop()
            {
                Console.WriteLine("Stopping ...");
            }

        }


        // ************  [Expelicit   Interface ]  ************


            /*
             * If two interfaces have methods with the same name, 
             * explicit implementation helps you resolve the conflict.
             * 
             */

        interface IMove
        {
            // ** you can use default implementation but only after c# 8

            //void Turn()
            //{
            //    Console.WriteLine("hej");
            //}

            void Move();
        }

        interface IParking
        {
            void Move();
        }

        class Car : IMove, IParking
        {
            void IMove.Move()
            {
                Console.WriteLine("Moving ...");
            }

            void IParking.Move()
            {
                Console.WriteLine("Parking ...");
            }
        }



        public static void TestInterface()
        {

            //ILoader v3 = new Caterpillar("Caterpillar pakistani", "KT4", 2020);

            //v3.Load();



            // ************  [Expelicit   Interface ]  ************


            IMove m = new Car();

            m.Move();
            //m.Turn(); after c# 8

        }
    }
}
