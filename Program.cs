using System;
using System.Linq;
using System.Collections.Generic;

namespace AvidTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Comment Here
                Console.WriteLine("Hello World!");
                AvidTest.UserEntry.GetNumberFromUser();




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to exit application ... ");
                Console.ReadKey();
            }
        }
    }
}
