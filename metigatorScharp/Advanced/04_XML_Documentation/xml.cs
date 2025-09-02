using System;


namespace Advanced._04_XML_Documentation
{
    /// <summary>
    /// The Main Generator Class
    /// </summary>
    /// <remarks>
    /// 
    /// This class can generate Ids and password 
    /// 
    /// </remarks>

    public class Generator
    {

        /// <value> value of last Id sequance   </value> 
        public static int LastIdSequence { get; private set; } = 1;


        /// <summary>
        /// Generate Employee Id by processing <paramref name="fname"/>, <paramref name="lname"/>, <paramref name="hireDate"/>
        /// 
        /// <list type="bullet"
        /// 
        /// <item>
        ///     
        ///<term>II</term>
        /// 
        /// <description> Employee Initials </description>
        /// 
        /// </item>
        /// 
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="hireDate"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string GenerateId(string fname, string lname, DateTime? hireDate)
        {
            // II YY MM DD 01

            if (fname == null)
                throw new InvalidOperationException($"{nameof(fname)} can not be null");

            if (lname == null)
                throw new InvalidOperationException($"{nameof(lname)} can not be null");

            if (hireDate == null)
            {
                hireDate = DateTime.Now;
            }
            else
            {
                if (hireDate.Value.Date < DateTime.Now.Date) // yyyy-MM-dd hh:mm:ss
                    throw new InvalidOperationException($"{nameof(hireDate)} can not be in the past");
            }

            var yy = hireDate.Value.ToString("yy");
            var mm = hireDate.Value.ToString("MM");
            var dd = hireDate.Value.ToString("dd");

            var code = $"{lname.ToUpper()[0]}{fname.ToUpper()[0]}{yy}{mm}{dd}{(LastIdSequence++).ToString().PadLeft(2, '0')}";
            return code;
        }

        public static string GenerateRandomPassword(int length)
        {
            const string ValidScope = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = "";
            Random rnd = new Random();

            while (0 < length--)
            {
                result += ValidScope[rnd.Next(ValidScope.Length)];
            }

            return result;
        }


    }


    public class xml
    {


        public static void TestXml()
        {

            do
            {
                Console.Write("Enter First Name : ");
                var fname = Console.ReadLine();


                Console.Write("Enter Last Name : ");
                var lname = Console.ReadLine();

                Console.Write("Hire Date : ");
                DateTime? hireDate = null;
                if (DateTime.TryParse(Console.ReadLine(), out DateTime hDate))
                    hireDate = hDate;

                var empId = Generator.GenerateId(fname, lname, hireDate);
                var rndmPassword = Generator.GenerateRandomPassword(8);

                Console.WriteLine($"{{\nId : {empId}, \nFirst Name = {fname}, \nLast Name = {lname}, \nHire Date = {hireDate} \nPassword = {rndmPassword} \n}}");


            } while (1 == 1);



        }

    }
}
