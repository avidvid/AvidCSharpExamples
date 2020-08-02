using System;
using System.Collections.Generic;
using System.Text;

namespace AvidTest
{
    class UserEntry
    {

        public static double GetNumberFromUser()
        {
            Console.WriteLine("Please entter a number");
            string userEntry = Console.ReadLine();
            double userParsedEntry;
            while (double.TryParse(userEntry, out userParsedEntry) == false)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid number");
                Console.WriteLine("Please entter a number");
                userEntry = Console.ReadLine();
            }
            Console.WriteLine($"You entered {userParsedEntry.ToString()}");
            return userParsedEntry;
        }
    }
}
