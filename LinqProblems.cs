using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AvidTest
{
    class LinqProblems
    {
        public class people
        {
            public int Age;
            public string Name;
            public bool IsManager;
            public DateTime Dob;
        }

        public static void LinqFilters(List<people> myList)
        {
            myList = myList.OrderByDescending(x => x.Name).ToList();
            myList = myList.OrderBy(x => x.Name).ThenByDescending(x => x.Age).ToList();
            myList = myList.Where(x => x.Age >25).OrderBy(x => x.Name).ToList();
            people manager = myList.Where(x => x.IsManager).FirstOrDefault() ?? throw new Exception("There was a problem finding a manager") ;

            int totalYears = myList.Where(x => x.Age > 25).Sum(x => x.Age);
        }
    }
}
