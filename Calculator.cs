using System;
using System.Collections.Generic;
using System.Text;

namespace AvidTest
{
    public static class Calculator
    {
        public static double MyAdd(double a, double b)
        {
            return a + b;
        }

        //Calculate sume of digits of a number 
        public static int Sum(int num)
        {
            if (num != 0)
            {
                return (num % 10 + Sum(num / 10));
            }
            else
            {
                return 0;
            }
        }


        //patern matching
        public static int ParsNumber(object num)
        {
            if (num is int output || num is string && int.TryParse((string)num, out output))
            {
                return output;
            }
            return 0;
        }

    }
}
