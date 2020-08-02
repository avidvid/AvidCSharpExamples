using System;
using System.Collections.Generic;
using System.Text;

namespace AvidTest
{
    class TuplesExample
    {
        public static (string firstName, string lasName) SplitName(string fullName)
        {
            string[] vals = fullName.Split(' ');
            return (vals[0], vals[1]);
        }
        public static void PrintName(string fullName)
        {
            var name = SplitName(fullName);
            Console.WriteLine($"Your name is {name.firstName}  and {name.lasName}");
        }
    }
}
