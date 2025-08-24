using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._03_Operator_Overloading
{

    public class Money
    {
        private decimal _amount;
        public decimal Amount => _amount;

        public Money(decimal value)
        {
            this._amount = Math.Round(value, 2);

        }

        public static Money operator + (Money money1, Money money2)
        {
            var result = money1.Amount + money2.Amount;

            return new Money(result);
        }


        public static bool operator > (Money money1, Money money2)
        {
            return money1.Amount > money2.Amount;
        }

        // you must declare  < also 
        public static bool operator < (Money money1, Money money2)
        {
            return money1.Amount > money2.Amount;
        }

        public static bool operator ==(Money money1, Money money2)
        {
            return money1.Amount == money2.Amount;
        }

        // you must declare  != also 
        public static bool operator !=(Money money1, Money money2)
        {
            return money1.Amount != money2.Amount;
        }


        // ++
        public static Money operator ++(Money money)
        {
            var result = money.Amount;

            return new Money(++result);
        }

        // --
        public static Money operator --(Money money)
        {
            var result = money.Amount;

            return new Money(--result);
        }


    }


    public class OPOverloading
    {
        public static void TestOPOverloading()
        {
            Money m1 = new Money(100);
            Money m2 = new Money(50);


            // ************  sum   ************



            //Console.WriteLine($"Money m1 : {m1.Amount}, Money m2 : {m2.Amount}");

            //Money m3 = m1 + m2; // Operator Overloading

            //Console.WriteLine("\nusing Operator Overloading : {0}", m3.Amount);



            // ************  Grater than > <  ************


            //Console.WriteLine(m1 > m2);
            //Console.WriteLine(m1 < m2);

            // ************  == !=  ************


            //Console.WriteLine(m1 == m2);
            //Console.WriteLine(m1 != m2);


            // ************   ++  --  ************


            Console.WriteLine($"++ {(++m1).Amount}");
            Console.WriteLine($"++ {(--m2).Amount}");


        }

    }
}

