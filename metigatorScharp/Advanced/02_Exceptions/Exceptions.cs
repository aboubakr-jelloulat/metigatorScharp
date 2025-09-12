using System;



namespace Advanced._02_Exceptions
{
    public  class clsExceptions
    {

        private static  void TestCatchMultipleEx()
        {
            try
            {
                int x = 0;
                if (x == 0)
                    throw new DivideByZeroException("hej !! Division by zero!");
                else if (x < 0)
                    throw new ArgumentException("Negative value not allowed!");
            }

            //catch (Exception ex)   // must be last
            //{
            //    Console.WriteLine("Other Exception: " + ex.Message);
            //}

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DivideByZeroException: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ArgumentException: " + ex.Message);
            }
            catch (Exception ex)   // must be last
            {
                Console.WriteLine("Other Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nEnd");
            }


        }




        class MyOwnException : Exception
        {
            // Always add constructors that match the base Exception
            public MyOwnException() { }

            public MyOwnException(string message) : base(message) { }

            public MyOwnException(string message, Exception inner)
                : base(message, inner) { }

        }

     
        public static void BuildMyOwnExeption()
        {
            try
            {
                int b = 0;

                if (b == 0)
                    throw new MyOwnException("Hej!! Division by zero!");
            }
            catch (MyOwnException ex)
            {
                Console.WriteLine($"Custom Exception caught: {ex.Message}");
            }
        }



        public static void TestExceptions()
        {

            //TestCatchMultipleEx();


            BuildMyOwnExeption();

        }

    }
}

