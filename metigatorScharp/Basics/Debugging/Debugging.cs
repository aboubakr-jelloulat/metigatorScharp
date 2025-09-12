using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Debugging
{
    public  class clsDebugging
    {

        static double CalculateFinalPrice(double price, double discountPercent)
        {
            // Expected: price * (1 - (discountPercent / 100))
            double result = price * 1 - discountPercent / 100;

            return result;
        }

        public static void TestDebugging()
        {

            double price = 100;
            double discount = 20; // 20%

            double finalPrice = CalculateFinalPrice(price, discount);

            Console.WriteLine($"Final Price = {finalPrice}");

        }

    }
}
