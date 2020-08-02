using System;
using System.Collections.Generic;
using System.Text;

namespace AvidTest
{
    class InterfaceExample
    {

        interface IPeople
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class Employee : IPeople
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Salary { get; set; }
        }
        public class Student : IPeople
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Grade { get; set; }
        }

        public static void SwitchPeople()
        {
            var collection = new List<IPeople>();
            foreach (var item in collection)
            {
                switch (item)
                {
                    case Employee e when (e.Salary > 0):
                        Console.WriteLine("Emplooyed");
                        break;
                    case Employee e when (e.Age > 80):
                        Console.WriteLine("Retired");
                        break;
                    case Student e when (e.Age > 7):
                        Console.WriteLine("School");
                        break;
                    case Student e when (e.Grade > 18):
                        Console.WriteLine("Top");
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
