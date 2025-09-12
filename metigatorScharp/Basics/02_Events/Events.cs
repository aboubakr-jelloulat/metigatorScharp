using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Basics._02_Events
{

    public class clsEvents
    {
        public delegate void StockPriceChangeHandler(Stock stock, decimal OldPrice);

        public static void TestEvents() // Subscriber
        {
            var stock = new Stock("Amazon");

            stock.Price = 100;

            stock.OnPriceChanged += Stock_OnPriceChanged;

            // *** using lambda expression 

            //stock.OnPriceChanged += (Stock s, decimal OldPrice) =>
            //{
            //    string state = "";

            //    if (OldPrice < s.Price)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        state = "UP";
            //    }
            //    else if (OldPrice > s.Price)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        state = "Down";
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.Gray;
            //        state = "STILL";
            //    }
            //    Console.WriteLine($"{s.Name} : {s.Price} - {state}");
            //};

            stock.ChangeStockPriceBy(0.5m);
            stock.ChangeStockPriceBy(-0.2m);
            stock.ChangeStockPriceBy(0.0m);

            // unsubscribe

            stock.OnPriceChanged -= Stock_OnPriceChanged;

            Console.WriteLine("\nAfter unsubscribe\n");

            stock.ChangeStockPriceBy(0.5m);
            stock.ChangeStockPriceBy(-0.2m);
            stock.ChangeStockPriceBy(0.0m);
        }

        private static void Stock_OnPriceChanged(Stock stock, decimal OldPrice)
        {
            string state = "";

            if (OldPrice < stock.Price)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                state = "UP";
            }
            else if (OldPrice > stock.Price)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                state = "Down";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                state = "STILL";
            }
            Console.WriteLine($"{stock.Name} : {stock.Price} - {state}");
        }
    }
}

